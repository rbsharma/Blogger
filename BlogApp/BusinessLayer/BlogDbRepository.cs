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
            return db.Posts.ToList();
        }

        public Post GetSinglePost(int id)
        {
            return db.Posts.First(x => x.Id == id);
        }

        public List<Post> SearchPostByTitle(string input)
        {
            input = input.ToLower();
            return db.Posts.Where(x => x.Title.ToLower().Contains(input)).ToList();
        }

        public List<Post> SearchPostByCategory(int id)
        {
            db.Tags.Find(id).Famous += 1;
            db.SaveChanges();
            return db.Posts.Where(x => x.Tags.FirstOrDefault(y => y.Id == id).Id == id).ToList();
        }

        public List<Tag> GetTags()
        {
            return db.Tags.OrderByDescending(x => x.Famous).ToList();
        }



    }
}