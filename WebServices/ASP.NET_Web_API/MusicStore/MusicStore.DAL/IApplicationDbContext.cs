namespace MusicStore.DAL.Repositories
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Microsoft.AspNet.Identity.EntityFramework;

    using MusicStore.Models;

    public interface IApplicationDbContext
    {
        IDbSet<Album> Albums { get; set; }

        IDbSet<Country> Countries { get; set; }

        IDbSet<Producer> Producers { get; set; }

        IDbSet<Song> Songs { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();

    }
}

