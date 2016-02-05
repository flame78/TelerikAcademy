using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoviesInformationalSystem.Data;
using MoviesInformationalSystem.Data.Models;

namespace MoviesInformationalSystem.Areas.Administration.Controllers
{
    using MoviesInformationalSystem.Controllers;

    public class MoviesController : AdministrationBaseController
    {
        // GET: Administration/Movies
        public ActionResult Index()
        {
            var movies = this.DbContext.Movies.Include(m => m.LeadingFemaleRole).Include(m => m.LeadingMaleRole).Include(m => m.Studio);
            return View(movies.ToList());
        }

        // GET: Administration/Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = this.DbContext.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Administration/Movies/Create
        public ActionResult Create()
        {
            ViewBag.LeadingFemaleRoleId = new SelectList(this.DbContext.Actors, "Id", "Name");
            ViewBag.LeadingMaleRoleId = new SelectList(this.DbContext.Actors, "Id", "Name");
            ViewBag.StudioId = new SelectList(this.DbContext.Studios, "Id", "Name");
            return View();
        }

        // POST: Administration/Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Year,StudioId,LeadingMaleRoleId,LeadingFemaleRoleId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                this.DbContext.Movies.Add(movie);
                this.DbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LeadingFemaleRoleId = new SelectList(this.DbContext.Actors, "Id", "Name", movie.LeadingFemaleRoleId);
            ViewBag.LeadingMaleRoleId = new SelectList(this.DbContext.Actors, "Id", "Name", movie.LeadingMaleRoleId);
            ViewBag.StudioId = new SelectList(this.DbContext.Studios, "Id", "Name", movie.StudioId);
            return View(movie);
        }

        // GET: Administration/Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = this.DbContext.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.LeadingFemaleRoleId = new SelectList(this.DbContext.Actors, "Id", "Name", movie.LeadingFemaleRoleId);
            ViewBag.LeadingMaleRoleId = new SelectList(this.DbContext.Actors, "Id", "Name", movie.LeadingMaleRoleId);
            ViewBag.StudioId = new SelectList(this.DbContext.Studios, "Id", "Name", movie.StudioId);
            return View(movie);
        }

        // POST: Administration/Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Year,StudioId,LeadingMaleRoleId,LeadingFemaleRoleId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                this.DbContext.Entry(movie).State = EntityState.Modified;
                this.DbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LeadingFemaleRoleId = new SelectList(this.DbContext.Actors, "Id", "Name", movie.LeadingFemaleRoleId);
            ViewBag.LeadingMaleRoleId = new SelectList(this.DbContext.Actors, "Id", "Name", movie.LeadingMaleRoleId);
            ViewBag.StudioId = new SelectList(this.DbContext.Studios, "Id", "Name", movie.StudioId);
            return View(movie);
        }

        // GET: Administration/Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = this.DbContext.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Administration/Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = this.DbContext.Movies.Find(id);
            this.DbContext.Movies.Remove(movie);
            this.DbContext.SaveChanges();
            return RedirectToAction("Index");
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
