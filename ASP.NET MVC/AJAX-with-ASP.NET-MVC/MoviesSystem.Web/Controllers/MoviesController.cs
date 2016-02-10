namespace MoviesSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using MoviesSystem.Data.Models;
    using MoviesSystem.Data.Services.Contracts;
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
            var movies = moviesServices.GetAll().Project().To<MovieViewModel>().ToList();
            return View(movies);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Studios = new SelectList(studiosServices.GetAll().ToList(), "Id", "Name");
            ViewBag.Actors = actorsServices.GetAll().ToList();
            return this.View(new Movie());
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                this.moviesServices.Create(movie);
                return this.RedirectToAction("Index");
            }

            ViewBag.Studios = new SelectList(studiosServices.GetAll().ToList(), "Id", "Name");
            ViewBag.Actors = actorsServices.GetAll().ToList();

            return View(movie);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var movie = moviesServices.GetById(id);
            ViewBag.Studios = new SelectList(studiosServices.GetAll().ToList(), "Id", "Name", movie.StudioId);
            ViewBag.Actors = actorsServices.GetAll().ToList();

            if (movie == null)
            {
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return View(movie);
            }

            moviesServices.Update(movie);

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var m = moviesServices.GetById(id);
            var movie = Mapper.Map<MovieDetailedViewModel>(m);
            if (movie == null)
            {
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var movie = Mapper.Map<MovieDetailedViewModel>(moviesServices.GetById(id));
            if (movie == null)
            {
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        [ActionName("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            moviesServices.DeleteById(id);

            return RedirectToAction("Index");
        }
    }
}