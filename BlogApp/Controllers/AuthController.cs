﻿using BlogApp.Helpers;
using BlogApp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
                    Session["user"] = model.Username;
                    return RedirectToActionPermanent("Index", "Blogs");
                }
                else
                {
                    ModelState.AddModelError("LoginFailure", "Username or Password is incorrect");
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
                    Session["user"] = model.Username;
                    return RedirectToActionPermanent("Index", "Blogs");
                }
                else
                {
                    ModelState.AddModelError("RegistrationFailure", "Username Exists");
                    return PartialView("_Register");
                }
            }
            return PartialView("_Register");
        }

        [HttpPost]
        public bool ValidateUsername(string _username)
        {
            return AuthManager.VerifyUsername(_username);  
        }

        public ActionResult Logout()
        {
            if (Request.Cookies["auth"] != null)
            {
                AuthManager.CookieClear();

                ViewBag.logout = "Successfully Logged out";
                return RedirectToActionPermanent("Index", "Blogs");
            }
            return RedirectToActionPermanent("Index", "Blogs");
        }
    }


}