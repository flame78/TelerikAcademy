namespace MoviesSystem.Data.Services.Contracts
{
    using System.Linq;

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