namespace Exam.DAL.Repositories
{
    using System.Data.Entity;
    using System.Linq;

    public class EFRepository<T> : IRepository<T> where T : class
    {

        private readonly IExamDbContext context;
        private readonly IDbSet<T> set;

        public EFRepository(IExamDbContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public T Add(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Added);
            return entity;
        }

        public IQueryable<T> All()
        {
            return this.set;
        }

        public T Delete(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Deleted);
            return entity;
        }

        public T Delete(object id)
        {
            var entity = this.Find(id);
            return this.Delete(entity);
        }

        public void Detach(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Detached);
        }

        public T Find(object id)
        {
            return this.set.Find(id);
        }

        public void Update(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Modified);
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private void ChangeEntityState(T entity, EntityState state)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            entry.State = state;
        }
    }
}
