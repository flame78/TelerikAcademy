using Microsoft.AspNet.Identity.EntityFramework;
using MusicStore.Models;
namespace MusicStore.DAL
{
    using System.Data.Entity;

    using MusicStore.DAL.Repositories;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IMusicStoreDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<Producer> Producers { get; set; }

        public IDbSet<Song> Songs { get; set; }

        public IDbSet<Album> Albums { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            throw new System.NotImplementedException();
        }
    }
}
