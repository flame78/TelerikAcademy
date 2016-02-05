namespace CustomRouteConstraint
{
    using System.Web.Mvc;
    using System.Web.Routing;

    using CustomRouteConstraint.CustomRouteConstraints;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Admin",
                url: "{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional },
                constraints: new { isControllerStartsWithAdmin = new AdminConstraint() });
        }
    }
}