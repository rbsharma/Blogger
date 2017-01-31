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
            return db.Posts.OrderByDescending(x=>x.PublishedAt).ToList();
        }

        public Post GetSinglePost(int id)
        {
            return db.Posts.First(x => x.Id == id);
        }

        public List<Post> SearchPostByTitle(string input)
        {
            input = input.ToLower();
            return db.Posts.Where(x => x.Title.ToLower().Contains(input)).OrderByDescending(x=>x.PublishedAt).ToList();
        }

        public List<Post> SearchPostByCategory(int id)
        {
            db.Tags.Find(id).Famous += 1;
            db.SaveChanges();
            return db.Posts.Where(x => x.Tags.FirstOrDefault(y => y.Id == id).Id == id)
                            .OrderByDescending(x=>x.PublishedAt).ToList();
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
        public bool InsertPost(string title,string description,int userid)
        {
            if(!(string.IsNullOrEmpty(title) && string.IsNullOrEmpty(description)))
            {
                Post newPost = new Post();
                newPost.Title = title;
                newPost.Description = description;
                newPost.PublishedAt = DateTime.Now;
                newPost.User = db.Users.Find(userid);

                db.Posts.Add(newPost);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool InsertComment(string title,int userid,int postid)
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


    }
}