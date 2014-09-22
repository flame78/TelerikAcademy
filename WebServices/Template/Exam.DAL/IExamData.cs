using System;
namespace Exam.DAL
{
    using Exam.DAL.Repositories;
    using Exam.Models;

    public interface IExamData
    {
        IRepository<Article> Articles { get; }

        IRepository<Category> Categories { get; }

        IRepository<Comment> Comments { get; }

        void SaveChanges();

        IRepository<Tag> Tags { get; }

        IRepository<ApplicationUser> User { get; }
    }
}
