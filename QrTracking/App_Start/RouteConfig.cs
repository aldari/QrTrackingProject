using System.Web.Mvc;
using System.Web.Routing;

namespace MasterDetail.WebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "first",
                url: "Index2",
                defaults: new { controller = "Home", action = "Index2" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{*Url}",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}
