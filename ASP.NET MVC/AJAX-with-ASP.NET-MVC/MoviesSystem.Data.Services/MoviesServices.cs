using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesSystem.Data.Services
{
    using System.Data.Entity.Migrations.Model;

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
            return movies.All();
        }

        public Movie GetById(int id)
        {
            return movies.GetById(id);
        }

        public void Create(Movie movie)
        {
            movies.Add(movie);
            movies.SaveChanges();
        }

        public void Update(Movie movie)
        {
            movies.Update(movie);
            movies.SaveChanges();
        }

        public void DeleteById(int id)
        {
            movies.Delete(movies.GetById(id));
            movies.SaveChanges();
        }
    }
}
