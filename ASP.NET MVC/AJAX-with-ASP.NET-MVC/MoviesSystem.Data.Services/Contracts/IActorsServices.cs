namespace MoviesSystem.Data.Services.Contracts
{
    using System.Linq;

    using MoviesSystem.Data.Models;

    public interface IActorsServices
    {
        IQueryable<Actor> GetAll();

        Actor GetById(int id);

        void Create(Actor actor);

        void UpdateById(int id, Actor updateActor);

        void DeleteById(int id);
    }
}