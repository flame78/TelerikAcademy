namespace BullsAndCows.DAL
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using BullsAndCows.Models;

    public interface IBullsAndCowsDbContext
    {
        IDbSet<Guess> Guesses { get; set; }

        IDbSet<Game> Games { get; set; }

        int SaveChanges();

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;
    }
}
