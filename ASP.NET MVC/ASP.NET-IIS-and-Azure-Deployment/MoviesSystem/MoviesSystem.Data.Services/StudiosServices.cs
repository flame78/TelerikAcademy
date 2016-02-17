namespace MoviesSystem.Data.Services
{
    using System;
    using System.Linq;

    using MoviesSystem.Data.Models;
    using MoviesSystem.Data.Repositories;
    using MoviesSystem.Data.Services.Contracts;

    public class StudiosServices : IStudiosServices
    {
        private IRepository<Studio> studios;

        public StudiosServices(IRepository<Studio> studios)
        {
            this.studios = studios;
        }

        public IQueryable<Studio> GetAll()
        {
            return this.studios.All();
        }

        public Studio GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(Studio movie)
        {
            throw new NotImplementedException();
        }

        public void Update(Studio movie)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}