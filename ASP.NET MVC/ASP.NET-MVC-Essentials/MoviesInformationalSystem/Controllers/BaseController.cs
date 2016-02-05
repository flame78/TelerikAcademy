namespace MoviesInformationalSystem.Controllers
{
    using System.Web.Mvc;

    using MoviesInformationalSystem.Data;

    public class BaseController : Controller
    {
        protected MoviesSystemDbContext DbContext;

        public BaseController()
        {
                DbContext = new MoviesSystemDbContext();
        }
    }
}