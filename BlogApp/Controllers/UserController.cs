using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogApp.Helpers;
using BlogApp.Models;
using BlogApp.Models.ViewModel;

namespace BlogApp.Controllers
{
    
    public class UserController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
    }
}