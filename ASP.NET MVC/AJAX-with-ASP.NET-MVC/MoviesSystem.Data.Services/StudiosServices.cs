using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesSystem.Data.Services.Contracts
{
    using MoviesSystem.Data.Models;
    using MoviesSystem.Data.Repositories;

    public class StudiosServices : IStudiosServices
    {
        private IRepository<Studio> studios; 

        public StudiosServices(IRepository<Studio> studios)
        {
            this.studios = studios;
        }

        public IQueryable<Studio> GetAll()
        {
            return studios.All();
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
