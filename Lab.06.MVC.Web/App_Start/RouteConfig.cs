using System.Web.Mvc;
using System.Web.Routing;

namespace Lab._06.MVC.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Movie", action = "GetAllMovies", id = UrlParameter.Optional }
            );
        }
    }
}
