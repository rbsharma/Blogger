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
        public List<Tag> GetTags()
        {
            return db.Tags.ToList();
        }

    }
}