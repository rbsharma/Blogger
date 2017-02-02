using BlogApp.Helpers;
using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApp.BusinessLayer
{
    public class BlogDbRepository
    {
        BlogDbContext db = new BlogDbContext();

        public List<Post> GetAllDbData()
        {
            return db.Posts.Include("User").Include("Tags").Include("Comments").ToList();
        }

        public List<Post> GetPosts()
        {
            return db.Posts.OrderByDescending(x => x.PublishedAt).ToList();
        }

        public Post GetSinglePost(int id)
        {
            return db.Posts.First(x => x.Id == id);
        }

        public List<Post> SearchPostByTitle(string input)
        {
            input = input.ToLower();
            return db.Posts.Where(x => x.Title.ToLower().Contains(input)).OrderByDescending(x => x.PublishedAt).ToList();
        }

        public List<Post> SearchPostByCategory(int id)
        {
            db.Tags.Find(id).Famous += 1;
            db.SaveChanges();
            return db.Posts.Where(x => x.Tags.FirstOrDefault(y => y.Id == id).Id == id)
                            .OrderByDescending(x => x.PublishedAt).ToList();
        }

        public List<Tag> GetTags()
        {
            return db.Tags.OrderByDescending(x => x.Famous).ToList();
        }

        public int GetUserId(string username)
        {
            return db.Users.FirstOrDefault(x => x.Name == username).Id;
        }
        public string GetUserName(int userid)
        {
            return db.Users.Find(userid).Name;
        }
        public bool InsertPost(string title, string description, int userid, string tagString)
        {
            if (!(string.IsNullOrEmpty(title) && string.IsNullOrEmpty(description)))
            {
                Tag newTag = new Tag();
                Tag exists = new Tag();
                List<Tag> tagsInNewPost = new List<Tag>();
                foreach (var item in tagString.Split(','))
                {
                    exists = db.Tags.FirstOrDefault(x => x.Title == item);
                    if (exists != null)
                    {
                        tagsInNewPost.Add(exists);
                        continue;
                    }
                    else
                    {
                        newTag.Title = item;
                        newTag.Famous = 0;
                        tagsInNewPost.Add(newTag);

                        db.Tags.Add(newTag);
                        db.SaveChanges();
                    }
                }


                Post newPost = new Post();
                newPost.Title = title;
                newPost.Description = description;
                newPost.PublishedAt = DateTime.Now;
                newPost.User = db.Users.Find(userid);
                newPost.Tags = tagsInNewPost;
                db.Posts.Add(newPost);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool InsertComment(string title, int userid, int postid)
        {
            if (!string.IsNullOrEmpty(title))
            {
                Comment newComment = new Comment();

                newComment.Title = title;
                newComment.PublishedAt = DateTime.Now;
                newComment.User = db.Users.Find(userid);
                newComment.Post = db.Posts.Find(postid);

                db.Comments.Add(newComment);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public List<Comment> GetComments(int postid)
        {
            return db.Comments.Where(x => x.Post.Id == postid).ToList();
        }
        public bool RemovePost(int postid)
        {
            Post postToRemove = db.Posts.Find(postid);
            if (postToRemove != null)
            {
                List<Tag> tagsToRemove = postToRemove.Tags.Where(x => x.Posts.Count == 1).ToList();
                List<Comment> commentsToRemove = postToRemove.Comments.ToList();

                tagsToRemove.ForEach(x => db.Tags.Remove(x));
                commentsToRemove.ForEach(x => db.Comments.Remove(x));
                db.Posts.Remove(postToRemove);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        //--------------------------------------------AUTHENTICATION RELATED----------------------------------------------------------------------------
        public bool Login(string username, string password)
        {
            password = Hasher.GetSha256Hash(password);
            return db.Users.Any(x => x.Name == username && x.Password == password);
        }

        public bool Register(string username, string password, string email)
        {
            if (db.Users.Any(x => x.Name == username))
            {
                //username exists;
                return false;
            }
            else
            {
                password = Hasher.GetSha256Hash(password);

                User currentUser = new User();
                currentUser.Name = username;
                currentUser.Password = password;
                currentUser.Email = email;

                db.Users.Add(currentUser);
                db.SaveChanges();
                return true;
            }
        }
        public bool UserExists(string input)
        {
            bool exists = db.Users.Any(x => x.Name == input);
            return exists;
        }

        public int generateUniqueId(string email)
        {
            
            User sadUser = db.Users.FirstOrDefault(x => x.Email == email);
            if (sadUser != null)
            {
                Random rd = new Random();
                int random = rd.Next(100000, 999999);
                sadUser.OTP = random;
                db.Entry(sadUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                SendMail(sadUser.Email, "Reset Password",random.ToString());
                return random;
            }
            return 0;
        }

        public bool verifyUniqueId(int key)
        {
            User sadUser = db.Users.FirstOrDefault(x => x.OTP == key);
            if(sadUser!= null)
            {
                HttpCookie temp = new HttpCookie("temp");
                temp.Value = key.ToString();
                temp.Expires = DateTime.Now.AddDays(1);
                HttpContext.Current.Response.Cookies.Add(temp);

                return true;
            }
            return false;
        }

        public bool ResetPassword(string Password)
        {
            HttpCookie tempCookie = HttpContext.Current.Request.Cookies["temp"];
            
            if (tempCookie != null)
            {
                int key = Convert.ToInt32(tempCookie.Value);
                User sadUser = db.Users.FirstOrDefault(x => x.OTP == key);
                sadUser.Password = Hasher.GetSha256Hash(Password);

                tempCookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(tempCookie);

                return true;
            }
            return false;
        }

        public void SendMail(string recepient,string Subject,string uniqueKey)
        {

        }

    }
}