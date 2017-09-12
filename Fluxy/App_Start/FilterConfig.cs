using Fluxy.Infrastructure;
using System.Web.Mvc;
using System.Web.Routing;

namespace Fluxy
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new RedirectToCanonicalUrlAttribute(RouteTable.Routes.AppendTrailingSlash,RouteTable.Routes.LowercaseUrls));
        }
    }
}
