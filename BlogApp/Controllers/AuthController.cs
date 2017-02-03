using BlogApp.Helpers;
using BlogApp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

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
                    return RedirectToAction("Index", "Blogs");
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
                    return RedirectToAction("Index", "Blogs");
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
                return RedirectToAction("Index", "Blogs");
            }
            return RedirectToAction("Index", "Blogs");
        }

        public JsonResult GetUsername(string userid)
        {
            string name = AuthManager.Username(Convert.ToInt32(userid));
            return Json(name);
        }

        public PartialViewResult Forgot()
        {
            return PartialView("_Forgot",new ForgotViewModel());
        }
        public ActionResult SendMail(ForgotViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (AuthManager.GenerateUniqueId(model.Email))
                {
                    ViewBag.sentmail = "If " + model.Email + " is linked to your account then an OTP will be sent to provided email.";
                    return PartialView("_OTP");
                }
            }
            return PartialView("_Forgot");
        }
        public ActionResult VerifyOTP(OtpViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (AuthManager.VerifyUniqueId(model.OTP))
                {
                    return PartialView("_ResetPassword");
                }
                ModelState.AddModelError("OTPFailure", "Invalid OTP");
            }
            return PartialView("_OTP");
        }

        public ActionResult ResetPassword(PasswordResetViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool isResetDone = AuthManager.ResetPassword(model.Password);
                if (isResetDone)
                {
                    return RedirectToAction("Login", "Auth");
                }
                ModelState.AddModelError("ResetFailure", "Something is wrong, please try again later.");
            }
            return PartialView("_ResetPassword");
        }
    }
}


