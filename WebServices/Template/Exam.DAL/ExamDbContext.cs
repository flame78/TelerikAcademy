namespace Exam.DAL
{
    using System.Data.Entity;

    using Exam.DAL.Migrations;
    using Exam.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class ExamDbContext : IdentityDbContext<ApplicationUser>, IExamDbContext
    {
        public ExamDbContext()
            : base("DefaultConnection", throwIfV1Schema: false )
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ExamDbContext, Configuration>());
        }
       
        public IDbSet<Article> Articles { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Tag> Tags { get; set; }

        public static ExamDbContext Create()
        {
            return new ExamDbContext();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }


    }
}
