namespace Exam.DAL
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Exam.Models;

    public interface IExamDbContext
    {
        IDbSet<Article> Articles { get; set; }

        IDbSet<Category> Categories { get; set; }

        int SaveChanges();

        IDbSet<T> Set<T>() where T : class;

        IDbSet<Tag> Tags { get; set; }

        DbEntityEntry<T> Entry<T>(T entity) where T : class;
    }
}
