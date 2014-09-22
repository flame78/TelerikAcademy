namespace Exam.DAL
{
    using System;
    using System.Collections.Generic;

    using Exam.DAL.Repositories;
    using Exam.Models;

    public class ExamData : IExamData
    {
        private readonly IExamDbContext context;

        private readonly IDictionary<Type, Object> repositories;

        public ExamData()
            : this(new ExamDbContext())
        {
        }

        public ExamData(IExamDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Article> Articles
        {
            get
            {
                return this.GetRepository<Article>();
            }
        }

        public IRepository<ApplicationUser> User
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                return this.GetRepository<Category>();
            }
        }

        public IRepository<Tag> Tags
        {
            get
            {
                return this.GetRepository<Tag>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                //var type = typeof(EFRepository<T>);
                //if (typeOfModel.IsAssignableFrom(typeof(Student)))
                //{
                //    type = typeof(StudentsRepository);
                //}

                var newRepository = Activator.CreateInstance(typeof(EFRepository<T>), this.context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}