using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MoviesInformationalSystem
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Custom",
                url: "",
                defaults: new
                {
                    controller = "Home",
                    action = "Movies",
                    id = UrlParameter.Optional

                },
                namespaces: new[] { "MoviesInformationalSystem.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                              {
                                  controller = "Home", action = "Index", id = UrlParameter.Optional 
                              
                              },
                namespaces: new[] { "MoviesInformationalSystem.Controllers" }
            );
        }
    }
}
