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
                bool isPostAdded = repo.InsertPost(model.Title, model.Description,userId);
                if (isPostAdded)
                {
                    ViewBag.addstatus = "Succesfully Added";
                    return View("Create");
                }
                ModelState.AddModelError("PostAddFailure", "An error occured, please try again..");
            }
            return View("Create");
        }

    }
}