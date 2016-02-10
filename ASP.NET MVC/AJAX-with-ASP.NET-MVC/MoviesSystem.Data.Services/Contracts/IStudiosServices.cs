using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesSystem.Data.Services.Contracts
{
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
