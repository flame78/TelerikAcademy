namespace MusicStore.DAL
{
    using System;
    using System.Collections.Generic;

    using MusicStore.DAL.Repositories;
    using MusicStore.Models;

    public class ApplicationData : IMusicStoreData
    {
        private readonly IMusicStoreDbContext context;
        private readonly Dictionary<Type, Object> repositories;

        public ApplicationData()
            : this(new ApplicationDbContext())
        {
        }

        public ApplicationData(IMusicStoreDbContext context)
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

        public IRepository<Country> Coutries
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
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(EFRepository<T>);

                //if (typeOfModel.IsAssignableFrom(typeof(Student)))
                //{
                //    type = typeof(StudentsRepository);
                //}

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }
    }
}
