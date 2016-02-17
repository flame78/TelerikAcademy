namespace MoviesSystem.Web
{
    using System.Data.Entity;

    using MoviesSystem.Data;
    using MoviesSystem.Data.Migrations;

    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MoviesSystemDbContext, Configuration>());
            MoviesSystemDbContext.Create().Database.Initialize(true);
        }
    }
}