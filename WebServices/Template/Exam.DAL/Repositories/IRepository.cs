namespace Exam.DAL.Repositories
{
    using System.Linq;

    public interface IRepository<T> where T : class
    {
        T Add(T entity);

        IQueryable<T> All();

        T Delete(T entity);

        T Delete(object id);

        void Detach(T entity);

        T Find(object id);

        void Update(T entity);

        int SaveChanges();
    }
}
