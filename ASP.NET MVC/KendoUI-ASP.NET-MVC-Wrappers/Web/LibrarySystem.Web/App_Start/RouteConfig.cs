namespace LibrarySystem.Web
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using System.Web.UI.WebControls;

    using Parameter = Autofac.Core.Parameter;

    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("BookDetails", "BookDetails/{id}", new { controller = "Books", action = "BookDetails" });

            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
