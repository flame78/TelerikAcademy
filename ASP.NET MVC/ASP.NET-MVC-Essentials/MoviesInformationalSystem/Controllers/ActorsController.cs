namespace MoviesInformationalSystem.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    public class ActorsController : BaseController
    {
        public ActionResult Index()
        {
            return View(this.DbContext.Actors.ToList());
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