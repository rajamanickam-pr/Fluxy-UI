using System.Web.Mvc;
using System.Web.Routing;

namespace Fluxy
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.AppendTrailingSlash = true;
            routes.LowercaseUrls = true;

            // IgnoreRoute - Tell the routing system to ignore certain routes for better performance.
            // Ignore .axd files.
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // Ignore everything in the Content folder.
            routes.IgnoreRoute("Content/{*pathInfo}");
            // Ignore everything in the Scripts folder.
            routes.IgnoreRoute("Scripts/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                     "Default",
                     "{controller}/{action}",
                      new { controller = "Home", action = "Index" }
                    );
        }
    }
}
