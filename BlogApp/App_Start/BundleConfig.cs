using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace BlogApp.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts")
                    //.Include("~/Scripts/jquery-{version}")
                    .IncludeDirectory("~/Scripts", "*.js"));

            bundles.Add(new StyleBundle("~/bundles/styles")
                .Include("~/Content/bootstrap.min.css", "~/Content/site.css"));
        }
    }
}