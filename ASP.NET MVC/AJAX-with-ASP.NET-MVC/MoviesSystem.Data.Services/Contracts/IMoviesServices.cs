using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesSystem.Data.Services.Contracts
{
    using MoviesSystem.Data.Models;

    public interface IMoviesServices
    {
        IQueryable<Movie> GetAll();

        Movie GetById(int id);

        void Create(Movie movie);

        void Update(Movie movie);

        void DeleteById(int id);
    }
}
