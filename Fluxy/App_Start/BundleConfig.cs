﻿using Fluxy.Core.Constants;
using System.Web.Optimization;

namespace Fluxy
{
    public static class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;
            AddCss(bundles);
            AddJavaScript(bundles);
        }

        private static void AddJavaScript(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                     "~/Scripts/jquery-3.1.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval",
                ContentDeliveryNetwork.Microsoft.JQueryValidateUrl).Include(
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.validate.unobtrusive.min.js",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                     "~/Scripts/tether.min.js",
                     "~/Scripts/bootstrap.js",
                     "~/Scripts/holder.min.js",
                     "~/Scripts/pace.min.js",
                      "~/Scripts/jquery.dataTables.min.js",
                      "~/Scripts/summernote/summernote.min.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/wow").Include(
                      "~/Scripts/wow.min.js"
                     ));
        }

        private static void AddCss(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/vendorcss").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/pace-theme-flash.css"
                      ));

            bundles.Add(new StyleBundle(
               "~/Content/fa",
               ContentDeliveryNetwork.MaxCdn.FontAwesomeUrl)
               .Include("~/Content/font-awesome.min.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css",
                      "~/Content/PagedList.css",
                       "~/Content/jquery.dataTables.min.css",
                       "~/Scripts/summernote/summernote.min.css",
                       "~/Content/animate.min.css"
                      ));
        }
    }
}