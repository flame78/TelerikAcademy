namespace MoviesSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using MoviesSystem.Data.Models;

    public interface IMoviesSystemDbContext : IDisposable
    {
        IDbSet<Actor> Actors { get; set; }

        IDbSet<Movie> Movies { get; set; }

        IDbSet<Studio> Studios { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}