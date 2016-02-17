namespace MoviesSystem.Web.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using MoviesSystem.Data;
    using MoviesSystem.Data.Models;
    using MoviesSystem.Web.Infrastructure.Constants;

    public class StudiosController : Controller
    {
        private MoviesSystemDbContext db = new MoviesSystemDbContext();

        public ActionResult Index()
        {
            return this.View(this.db.Studios.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studio studio = this.db.Studios.Find(id);
            if (studio == null)
            {
                return this.HttpNotFound();
            }
            return this.View(studio);
        }

        [Authorize]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,Name,Address")] Studio studio)
        {
            if (this.ModelState.IsValid)
            {
                this.db.Studios.Add(studio);
                this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View(studio);
        }

        [Authorize(Roles = MoviesSystemRoles.Administrator)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studio studio = this.db.Studios.Find(id);
            if (studio == null)
            {
                return this.HttpNotFound();
            }
            return this.View(studio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = MoviesSystemRoles.Administrator)]
        public ActionResult Edit([Bind(Include = "Id,Name,Address")] Studio studio)
        {
            if (this.ModelState.IsValid)
            {
                this.db.Entry(studio).State = EntityState.Modified;
                this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }
            return this.View(studio);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studio studio = this.db.Studios.Find(id);
            if (studio == null)
            {
                return this.HttpNotFound();
            }
            return this.View(studio);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Studio studio = this.db.Studios.Find(id);
            this.db.Studios.Remove(studio);
            this.db.SaveChanges();
            return this.RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}