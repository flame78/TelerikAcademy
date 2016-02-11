using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Data.Uow
{
    public interface IGenericRepository<T, in TKey> where T : class
    {
        IQueryable<T> All();

        T GetById(TKey id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void DeleteById(TKey id);

        void Detach(T entity);
    }
}
