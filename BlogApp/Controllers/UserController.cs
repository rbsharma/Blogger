using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogApp.Helpers;
using BlogApp.Models;
using BlogApp.Models.ViewModel;
using BlogApp.BusinessLayer;

namespace BlogApp.Controllers
{
    [CustomAuthorization]
    [HandleError]
    public class UserController : Controller
    {
        BlogDbRepository repo = new BlogDbRepository();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddPost()
        {
            return View("Create");
        }
        [HttpPost]
        public ActionResult AddPost(PostViewModel model)
        {
            if (ModelState.IsValid)
            {
                int userId = Convert.ToInt32(Request.Cookies["user"].Value);
                TempData["userid"] = userId;
                bool isPostAdded = repo.InsertPost(model.Title, model.Description, userId,model.TagString);
                if (isPostAdded)
                {
                    ViewBag.addstatus = "Succesfully Added";
                    return RedirectToAction("Index", "Blogs");
                    //return View("Create");
                }
                ModelState.AddModelError("PostAddFailure", "An error occured, please try again..");
            }
            return View("Create");
        }

        [HttpPost]
        public ActionResult AddComment(CommentViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool isCommentAdded = repo.InsertComment(model.Title, model.userid, model.postid);
                if (isCommentAdded)
                {
                    ViewBag.addstatus = "Succesfully Added";
                    List<Comment> postComments = repo.GetComments(model.postid);
                    return PartialView("_Comments", postComments);
                }
                ModelState.AddModelError("CommentAddFailure", "An error occured, please try again..");
            }
            return PartialView("_AddComment", new CommentViewModel());
        }
        
        public ActionResult DeletePost(int postid)
        {
            if (postid > 0)
            {
                bool IsPostRemoved = repo.RemovePost(postid);
                if (IsPostRemoved)
                {
                    return RedirectToAction("Index", "Blogs");
                }
            }
            return RedirectToAction("Blog", "Blogs", postid);
        }

    }
}