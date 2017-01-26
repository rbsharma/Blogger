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
        [OutputCache(Duration =10)]
        public ActionResult Index()
        {
            List<Post> PostList = repo.GetPosts();
            return View(PostList);
        }

        [ChildActionOnly]
        [OutputCache(Duration =10)]
        public PartialViewResult Tags()
        {
            List<Tag> TagList = repo.GetTags();
            List<Tag> topTags = TagList.Take(10).ToList();
            return PartialView("_TagBox", topTags);
        }


        public ActionResult SearchBlog(string input)
        {
            if (input != null)
            {
                ViewBag.searchInput = input;
                List<Post> searchedPosts = repo.SearchPostByTitle(input);
                return View("SearchResult", searchedPosts);
            }
            return RedirectToAction("Index");
        }
        public ActionResult SearchBlogByTag(int id,string title)
        {
            if (id.ToString() !=null)
            {
                ViewBag.searchInput = title;
                List<Post> searchedPosts = repo.SearchPostByCategory(id);
                return View("SearchResult", searchedPosts);
            }
            return RedirectToAction("Index");
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