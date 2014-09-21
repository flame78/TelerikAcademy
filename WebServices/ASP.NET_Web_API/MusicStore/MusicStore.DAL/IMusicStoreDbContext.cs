namespace MusicStore.DAL.Repositories
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using MusicStore.Models;

    public interface IMusicStoreDbContext
    {
        IDbSet<Album> Albums { get; set; }

        IDbSet<Country> Countries { get; set; }

        IDbSet<Producer> Producers { get; set; }

        IDbSet<Song> Songs { get; set; }

        int SaveChanges();

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}

