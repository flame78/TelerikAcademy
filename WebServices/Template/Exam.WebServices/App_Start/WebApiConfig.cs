namespace Exam.WebServices
{
    using System.Web.Http;
    using System.Web.Http.Cors;

    using Microsoft.Owin.Security.OAuth;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

           //config.Routes.MapHttpRoute(
           //     name: "Comments",
           //     routeTemplate: "api/articles/{id}/comments",
           //     defaults: new
           //     {
           //         controller = "Comments",
           //     }
           // );

            config.Routes.MapHttpRoute(
                 name: "ArticleDetails",
                 routeTemplate: "api/articles/{id}",
                 defaults: new
                 {
                     controller = "Articles",
                     action = "Details"
                 }
             );

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}/{action}", 
                new
                    {
                        id = RouteParameter.Optional,
                        action = RouteParameter.Optional
                    });

            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
           
        }
    }
}