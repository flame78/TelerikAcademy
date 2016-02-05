namespace MoviesInformationalSystem.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    public class MoviesController : BaseController
    {
        // GET: Movies
        public ActionResult Index()
        {
            var movies =
                this.DbContext.Movies.Include(m => m.LeadingFemaleRole)
                    .Include(m => m.LeadingMaleRole)
                    .Include(m => m.Studio);
            return View(movies.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.DbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}