using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogApp.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Error()
        {
            return View();
        }
        public ActionResult NotFound()
        {
            return View("NotFound");
        }
        public ActionResult InternalError()
        {
            return View("InternalError");
        }
    }
}