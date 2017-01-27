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

        public static bool VerifyLogin(LoginViewModel model)
        {
                if(repo.Login(model.Username, model.Password))
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
            if(repo.Register(model.Username, model.Password, model.Email))
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
            HttpCookie auth = new HttpCookie("auth");
            auth.Expires = DateTime.Now.AddDays(10);
            _user = Hasher.GetSha256Hash(_user);
            auth.Value = _user;
            HttpContext.Current.Response.Cookies.Add(auth);
        }

    }
}