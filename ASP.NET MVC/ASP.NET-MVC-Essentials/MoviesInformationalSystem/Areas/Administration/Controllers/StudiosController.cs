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
    public class StudiosController : AdministrationBaseController
    {
        // GET: Administration/Studios
        public ActionResult Index()
        {
            return View(this.DbContext.Studios.ToList());
        }

        // GET: Administration/Studios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studio studio = this.DbContext.Studios.Find(id);
            if (studio == null)
            {
                return HttpNotFound();
            }
            return View(studio);
        }

        // GET: Administration/Studios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/Studios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address")] Studio studio)
        {
            if (ModelState.IsValid)
            {
                this.DbContext.Studios.Add(studio);
                this.DbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studio);
        }

        // GET: Administration/Studios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studio studio = this.DbContext.Studios.Find(id);
            if (studio == null)
            {
                return HttpNotFound();
            }
            return View(studio);
        }

        // POST: Administration/Studios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address")] Studio studio)
        {
            if (ModelState.IsValid)
            {
                this.DbContext.Entry(studio).State = EntityState.Modified;
                this.DbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studio);
        }

        // GET: Administration/Studios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studio studio = this.DbContext.Studios.Find(id);
            if (studio == null)
            {
                return HttpNotFound();
            }
            return View(studio);
        }

        // POST: Administration/Studios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Studio studio = this.DbContext.Studios.Find(id);
            this.DbContext.Studios.Remove(studio);
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
