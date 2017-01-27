using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace BlogApp.Helpers
{
    public class CustomAuthorization : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.Cookies["auth"] == null)
            {
                var route = new RouteValueDictionary();
                route["Controller"] = "Auth";
                route["Action"] = "Login";
                filterContext.Result = new RedirectToRouteResult(route);

                //filterContext.Result = new RedirectToRouteResult(
                //                  new RouteValueDictionary
                //                  {
                //                       { "action", "ActionName" },
                //                       { "controller", "ControllerName" }
                //                  });
            }
        }
    }
}