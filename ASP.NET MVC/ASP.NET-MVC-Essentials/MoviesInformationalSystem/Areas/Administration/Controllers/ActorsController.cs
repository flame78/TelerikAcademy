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

    public class ActorsController : AdministrationBaseController
    {
        // GET: Administration/Actors
        public ActionResult Index()
        {
            return View(this.DbContext.Actors.ToList());
        }

        // GET: Administration/Actors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actor actor = this.DbContext.Actors.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // GET: Administration/Actors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/Actors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,BirthYear")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                this.DbContext.Actors.Add(actor);
                this.DbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(actor);
        }

        // GET: Administration/Actors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actor actor = this.DbContext.Actors.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // POST: Administration/Actors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,BirthYear")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                this.DbContext.Entry(actor).State = EntityState.Modified;
                this.DbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(actor);
        }

        // GET: Administration/Actors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actor actor = this.DbContext.Actors.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // POST: Administration/Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Actor actor = this.DbContext.Actors.Find(id);
            this.DbContext.Actors.Remove(actor);
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
