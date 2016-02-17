namespace MoviesSystem.Data.Services
{
    using System.Linq;

    using MoviesSystem.Data.Models;
    using MoviesSystem.Data.Repositories;
    using MoviesSystem.Data.Services.Contracts;

    public class ActorsServices : IActorsServices
    {
        private IRepository<Actor> actors;

        public ActorsServices(IRepository<Actor> actors)
        {
            this.actors = actors;
        }

        public IQueryable<Actor> GetAll()
        {
            return this.actors.All();
        }

        public Actor GetById(int id)
        {
            return this.actors.GetById(id);
        }

        public void Create(Actor actor)
        {
            this.actors.Add(actor);
            this.actors.SaveChanges();
        }

        public void UpdateById(int id, Actor updateActor)
        {
            var actorToUpdate = this.actors.GetById(id);

            actorToUpdate.BirthYear = updateActor.BirthYear;
            actorToUpdate.Gender = updateActor.Gender;
            actorToUpdate.Name = updateActor.Name;
            this.actors.SaveChanges();
        }

        public void DeleteById(int id)
        {
            this.actors.Delete(id);
            this.actors.SaveChanges();
        }
    }
}