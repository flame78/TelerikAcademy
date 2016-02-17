namespace MoviesSystem.Data.Services
{
    using System.Linq;

    using MoviesSystem.Data.Models;
    using MoviesSystem.Data.Repositories;
    using MoviesSystem.Data.Services.Contracts;

    public class MoviesServices : IMoviesServices
    {
        private IRepository<Movie> movies;

        public MoviesServices(IRepository<Movie> movies)
        {
            this.movies = movies;
        }

        public IQueryable<Movie> GetAll()
        {
            return this.movies.All();
        }

        public Movie GetById(int id)
        {
            return this.movies.GetById(id);
        }

        public void Create(Movie movie)
        {
            this.movies.Add(movie);
            this.movies.SaveChanges();
        }

        public void Update(Movie movie)
        {
            this.movies.Update(movie);
            this.movies.SaveChanges();
        }

        public void DeleteById(int id)
        {
            this.movies.Delete(this.movies.GetById(id));
            this.movies.SaveChanges();
        }
    }
}