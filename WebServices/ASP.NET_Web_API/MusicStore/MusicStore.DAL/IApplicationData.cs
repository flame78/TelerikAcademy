namespace MusicStore.DAL
{
    using MusicStore.DAL.Repositories;
    using MusicStore.Models;

    public interface IApplicationData
    {
        IRepository<Album> Albums { get; }

        IRepository<ApplicationUser> Artists { get; }

        IRepository<Country> Countries { get; }

        IRepository<Producer> Producers { get; }

        IRepository<Song> Songs { get; } 

        void SaveChanges();
    }
}
