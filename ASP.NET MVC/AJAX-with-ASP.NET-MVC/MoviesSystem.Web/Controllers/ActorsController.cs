namespace MoviesSystem.Web.Controlers
{
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using MoviesSystem.Data.Models;
    using MoviesSystem.Data.Services.Contracts;
    using MoviesSystem.Web.Models;

    public class ActorsController : Controller
    {
        private readonly IActorsServices actorsServices;

        public ActorsController(IActorsServices actorsServices)
        {
            this.actorsServices = actorsServices;
        }

        public ActionResult Index()
        {
            var actors = this.actorsServices.GetAll().Project().To<ActorViewModel>().ToList();
            return View(actors);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var actor = AutoMapper.Mapper.Map<ActorViewModel>(this.actorsServices.GetById((int)id));
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ActorViewModel actor)
        {
            if (this.ModelState.IsValid)
            {
                this.actorsServices.Create(AutoMapper.Mapper.Map<Actor>(actor));
                return this.RedirectToAction("Index");
            }

            return this.View(actor);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var actor = AutoMapper.Mapper.Map<ActorViewModel>(this.actorsServices.GetById((int)id));
            if (actor == null)
            {
                return this.HttpNotFound();
            }

            return this.View(actor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ActorViewModel actor)
        {
            if (this.ModelState.IsValid)
            {
                actorsServices.UpdateById(actor.Id, AutoMapper.Mapper.Map<Actor>(actor));
                return this.RedirectToAction("Index");
            }
            return this.View(actor);
        }
    }
}