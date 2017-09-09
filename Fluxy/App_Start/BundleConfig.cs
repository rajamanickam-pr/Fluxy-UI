using System.Web.Optimization;

namespace Fluxy
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.1.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                     "~/Scripts/tether.min.js",
                     "~/Scripts/bootstrap.js",
                     "~/Scripts/holder.min.js",
                     "~/Scripts/pace.min.js",
                     "~/Scripts/jquery.unobtrusive-ajax.min.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/adminScript").Include(
                       "~/Areas/Admin/Scripts/Helpers.js",
                       "~/Areas/Admin/Scripts/jquery.dataTables.min.js"));

            bundles.Add(new StyleBundle("~/Content/admincss").Include(
                    "~/Areas/Admin/Content/AdminStyles.css", 
                    "~/Areas/Admin/Content/jquery.dataTables.min.css"
                     ));

            bundles.Add(new StyleBundle("~/Content/vendorcss").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/pace-theme-flash.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css",
                      "~/Content/PagedList.css"
                      ));
        }
    }
}