namespace MoviesInformationalSystem.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using MoviesInformationalSystem.Models;

    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Movies()
        {
            var movies =
                DbContext.Movies.Select(
                    m =>
                    new MovieViewModel()
                        {
                            Title = m.Title,
                            Year = m.Year,
                            LeadingMaleRoleName = m.LeadingMaleRole.Name,
                            LeadingFemaleRoleName = m.LeadingFemaleRole.Name
                        }).ToList();

            return View(movies);
        }

        public ActionResult Actors()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Studios()
        {
            return null;
        }
    }
}