namespace MoviesSystem.Data.Services.Contracts
{
    using System.Linq;

    using MoviesSystem.Data.Models;

    public interface IStudiosServices
    {
        IQueryable<Studio> GetAll();

        Studio GetById(int id);

        void Create(Studio movie);

        void Update(Studio movie);

        void DeleteById(int id);
    }
}