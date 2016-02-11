using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Data.Uow
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Twitter.Data.Models;

    public class TwitterUow : ITwitterUow
    {
        private readonly TwitterDbContext context;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public TwitterUow(TwitterDbContext context)
        {
            this.context = context;
        }

        public IGenericRepository<User, string> Users
        {
            get
            {
                return this.GetRepository<User, string>();
            }
        }

        public IGenericRepository<Tweet, int> Tweets
        {
            get
            {
                return this.GetRepository<Tweet, int>();
            }
        }

        public IGenericRepository<Tag, string> Tags
        {
            get
            {
                return this.GetRepository<Tag, string>();
            }
        }

        public int Save()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            if (this.context != null)
            {
                this.context.Dispose();
            }
        }

        private IGenericRepository<T, TKey> GetRepository<T, TKey>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T, TKey>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T, TKey>)this.repositories[typeof(T)];
        }
    }
}
