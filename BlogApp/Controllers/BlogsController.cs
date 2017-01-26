using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogApp.BusinessLayer;
using BlogApp.Models;

namespace BlogApp.Controllers
{
    public class BlogsController : Controller
    {
        BlogDbRepository repo = new BlogDbRepository();
        public ActionResult Index()
        {
            List<Post> PostList = repo.GetPosts();
            return View(PostList);
        }

        [ChildActionOnly]
        public PartialViewResult Tags()
        {
            List<Tag> TagList = repo.GetTags();
            List<Tag> topTags = TagList.Take(10).ToList();
            return PartialView("_TagBox", topTags);
        }

        public PartialViewResult SearchBlog()
        {
            return PartialView("_SearchBox");
        }


        /// <summary>
        /// returns a single blog
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Blog(int id)
        {
            Post currentPost =  repo.GetSinglePost(id);
            return View("SinglePost",currentPost);
        }
    }
}