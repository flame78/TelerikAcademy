namespace BullsAndCows.DAL
{
    using System.Data.Entity;

    using BullsAndCows.DAL.Migrations;
    using BullsAndCows.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class BullsAndCowsDbContext : IdentityDbContext<User>, IBullsAndCowsDbContext
    {
        public BullsAndCowsDbContext()
            : base("DefaultConnection", throwIfV1Schema: false )
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BullsAndCowsDbContext, Configuration>());
        }
       
        public IDbSet<Guess> Guesses { get; set; }

        public IDbSet<Game> Games { get; set; } 

        public static BullsAndCowsDbContext Create()
        {
            return new BullsAndCowsDbContext();
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
