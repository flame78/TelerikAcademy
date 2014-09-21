using Microsoft.AspNet.Identity.EntityFramework;
using MusicStore.Models;
namespace MusicStore.DAL
{
    using System.Data.Entity;

    using MusicStore.DAL.Migrations;
    using MusicStore.DAL.Repositories;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false )
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }
       
        public IDbSet<Country> Countries { get; set; }

        public IDbSet<Producer> Producers { get; set; }

        public IDbSet<Song> Songs { get; set; }

        public IDbSet<Album> Albums { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //public new void SaveChanges()
        //{
        //    base.SaveChanges();
        //}

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }


    }
}
