using BlogApp.Helpers;
using BlogApp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogApp.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            if (Request.Cookies["auth"] != null)
            {
                return RedirectToAction("Index", "Blogs");
            }
            return PartialView("_Login");
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (AuthManager.VerifyLogin(model))
                {
                    return RedirectToAction("Index", "Blogs");
                }
                else
                {
                    ModelState.AddModelError("Login Failure", "Username or Password is incorrect");
                    return PartialView("_Login");
                }
            }
            return PartialView("_Login");

        }

        [HttpGet]
        public ActionResult Register()
        {
            if (Request.Cookies["auth"] != null)
            {
                return RedirectToAction("Index", "Blogs");
            }
            return PartialView("_Register");
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (AuthManager.RegisterUser(model))
                {
                    return RedirectToAction("Index", "Blogs");
                }
                else
                {
                    ViewBag.regFailure = "Username Exists";
                    return PartialView("_Register");
                }
            }
            return PartialView("_Register");
        }

        [ChildActionOnly]
        public ActionResult Logout()
        {
            if (Request.Cookies["auth"] != null)
            {
                Request.Cookies["auth"].Expires = DateTime.Now.AddDays(-1);
                ViewBag.logout = "Successfully Logged out";
                return RedirectToAction("Index", "Blog");
            }
            return RedirectToAction("Index", "Blog");
        }
    }

    
}