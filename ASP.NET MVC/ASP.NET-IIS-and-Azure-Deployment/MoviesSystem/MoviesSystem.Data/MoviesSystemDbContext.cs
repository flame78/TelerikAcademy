namespace MoviesSystem.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using MoviesSystem.Data.Migrations;
    using MoviesSystem.Data.Models;

    public class MoviesSystemDbContext : IdentityDbContext<User>, IMoviesSystemDbContext
    {
        public MoviesSystemDbContext()
            : base("MoviesSystemDb", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MoviesSystemDbContext, Configuration>());
        }

        public IDbSet<Movie> Movies { get; set; }

        public IDbSet<Actor> Actors { get; set; }

        public IDbSet<Studio> Studios { get; set; }

        public static MoviesSystemDbContext Create()
        {
            return new MoviesSystemDbContext();
        }
    }
}