namespace CustomRouteConstraint.CustomRouteConstraints
{
    using System.Web;
    using System.Web.Routing;

    public class AdminConstraint : IRouteConstraint
    {
        public bool Match(
            HttpContextBase httpContext,
            Route route,
            string parameterName,
            RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            bool isControllerStartWithAdmin = values["controller"].ToString().ToLower().StartsWith("admin");
            return isControllerStartWithAdmin;
        }
    }
}