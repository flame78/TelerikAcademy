namespace MusicStore.DAL
{
    using System;
    using System.Collections.Generic;

    using MusicStore.DAL.Repositories;
    using MusicStore.Models;

    public class ApplicationData : IApplicationData
    {
        private readonly IApplicationDbContext context;
        private readonly IDictionary<Type, Object> repositories;

        //public ApplicationData()
        //    : this(new ApplicationDbContext())
        //{
        //}

        public ApplicationData(IApplicationDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Album> Albums
        {
            get
            {
                return this.GetRepository<Album>();
            }
        }

        public IRepository<ApplicationUser> Artists
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        public IRepository<Country> Countries
        {
            get
            {
                return this.GetRepository<Country>();
            }
        }

        public IRepository<Producer> Producers
        {
            get
            {
                return this.GetRepository<Producer>();
            }
        }

        public IRepository<Song> Songs
        {
            get
            {
                return this.GetRepository<Song>();
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

                var newRepository = Activator.CreateInstance(typeof(EFRepository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}
