namespace MoviesInformationalSystem.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using MoviesInformationalSystem.Data;
    using MoviesInformationalSystem.Data.Models;

    public class StudiosController : BaseController
    {
        // GET: Studios
        public ActionResult Index()
        {
            return View(this.DbContext.Studios.ToList());
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