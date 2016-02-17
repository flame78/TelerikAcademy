namespace MoviesSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using MoviesSystem.Data.Models;
    using MoviesSystem.Data.Services.Contracts;
    using MoviesSystem.Web.Infrastructure.Constants;
    using MoviesSystem.Web.Models;

    public class MoviesController : Controller
    {
        private readonly IActorsServices actorsServices;

        private readonly IMoviesServices moviesServices;

        private readonly IStudiosServices studiosServices;

        public MoviesController(
            IMoviesServices moviesServices,
            IStudiosServices studiosServices,
            IActorsServices actorsServices)
        {
            this.moviesServices = moviesServices;
            this.studiosServices = studiosServices;
            this.actorsServices = actorsServices;
        }

        // GET: Movies
        public ActionResult Index()
        {
            var movies = this.moviesServices.GetAll().Project().To<MovieViewModel>().ToList();
            return this.View(movies);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            this.ViewBag.Studios = new SelectList(this.studiosServices.GetAll().ToList(), "Id", "Name");
            this.ViewBag.Actors = this.actorsServices.GetAll().ToList();
            return this.View(new Movie());
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(Movie movie)
        {
            if (this.ModelState.IsValid)
            {
                this.moviesServices.Create(movie);
                return this.RedirectToAction("Index");
            }

            this.ViewBag.Studios = new SelectList(this.studiosServices.GetAll().ToList(), "Id", "Name");
            this.ViewBag.Actors = this.actorsServices.GetAll().ToList();

            return this.View(movie);
        }

        [HttpGet]
        [Authorize(Roles = MoviesSystemRoles.Administrator)]
        public ActionResult Edit(int id)
        {
            var movie = this.moviesServices.GetById(id);
            this.ViewBag.Studios = new SelectList(this.studiosServices.GetAll().ToList(), "Id", "Name", movie.StudioId);
            this.ViewBag.Actors = this.actorsServices.GetAll().ToList();

            if (movie == null)
            {
                return this.RedirectToAction("Index");
            }

            return this.View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = MoviesSystemRoles.Administrator)]
        public ActionResult Edit(Movie movie)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(movie);
            }

            this.moviesServices.Update(movie);

            return this.RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var m = this.moviesServices.GetById(id);
            var movie = Mapper.Map<MovieDetailedViewModel>(m);
            if (movie == null)
            {
                return this.RedirectToAction("Index");
            }

            return this.View(movie);
        }

        [HttpGet]
        [Authorize(Roles = MoviesSystemRoles.Administrator)]
        public ActionResult Delete(int id)
        {
            var movie = Mapper.Map<MovieDetailedViewModel>(this.moviesServices.GetById(id));
            if (movie == null)
            {
                return this.RedirectToAction("Index");
            }

            return this.View(movie);
        }

        [ActionName("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = MoviesSystemRoles.Administrator)]
        public ActionResult DeleteConfirmed(int id)
        {
            this.moviesServices.DeleteById(id);

            return this.RedirectToAction("Index");
        }
    }
}