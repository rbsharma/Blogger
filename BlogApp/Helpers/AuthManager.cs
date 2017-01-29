using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogApp.BusinessLayer;
using BlogApp.Models.ViewModel;

namespace BlogApp.Helpers
{
    public static class AuthManager
    {
        static BlogDbRepository repo = new BlogDbRepository();

        public static bool VerifyUsername(string _username)
        {
            return repo.UserExists(_username);
        }
        public static bool VerifyLogin(LoginViewModel model)
        {
            if (repo.Login(model.Username, model.Password))
            {
                CookieCreator(model.Username);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool RegisterUser(RegisterViewModel model)
        {
            if (repo.Register(model.Username, model.Password, model.Email))
            {
                CookieCreator(model.Username);
                return true;
            }
            else
            {
                //username exists
                return false;
            }
        }

        public static void CookieCreator(string _user)
        {
            HttpCookie user = new HttpCookie("user");
            user.Expires = DateTime.Now.AddDays(10);
            user.Value = repo.GetUserId(_user).ToString();

            HttpCookie auth = new HttpCookie("auth");
            auth.Expires = DateTime.Now.AddDays(10);
            _user = Hasher.GetSha256Hash(_user);
            auth.Value = _user;

            HttpContext.Current.Response.Cookies.Add(auth);
            HttpContext.Current.Response.Cookies.Add(user);
        }

        public static void CookieClear()
        {
            HttpCookie authCookie = HttpContext.Current.Request.Cookies["auth"];
            authCookie.Expires = DateTime.Now.AddDays(-1);

            HttpCookie userCookie = HttpContext.Current.Request.Cookies["user"];
            userCookie.Expires = DateTime.Now.AddDays(-1);

            HttpCookie sessionCookie = HttpContext.Current.Request.Cookies["ASP.NET_SessionId"];
            sessionCookie.Expires = DateTime.Now.AddDays(-1);

            HttpContext.Current.Response.Cookies.Add(authCookie);
            HttpContext.Current.Response.Cookies.Add(sessionCookie);
            HttpContext.Current.Response.Cookies.Add(userCookie);

            HttpContext.Current.Session.Abandon();
        }

    }
}