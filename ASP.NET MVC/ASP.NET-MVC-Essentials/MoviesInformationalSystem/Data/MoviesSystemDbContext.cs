namespace MoviesInformationalSystem.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using MoviesInformationalSystem.Data.Migrations;
    using MoviesInformationalSystem.Data.Models;

    public class MoviesSystemDbContext : IdentityDbContext<User>
    {
        public MoviesSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MoviesSystemDbContext, Configuration>());
        }

        public static MoviesSystemDbContext Create()
        {
            return new MoviesSystemDbContext();
        }

        public IDbSet<Movie> Movies { get; set; }

        public IDbSet<Actor> Actors { get; set; }

        public IDbSet<Studio> Studios  { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder
        //        .Entity<Movie>()
        //        .HasRequired(p => p.)
        //        .WithMany(x => x.Articles)
        //        .WillCascadeOnDelete(true);

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
