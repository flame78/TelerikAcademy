namespace Twitter.Web
{
    using System.Data.Entity;

    using Twitter.Data;
    using Twitter.Data.Migrations;

    public class DbConfig
    {
        public static void Init()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TwitterDbContext, Configuration>());
        }
    }
}
