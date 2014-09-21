namespace MusicStore.DAL
{
    using MusicStore.DAL.Repositories;
    using MusicStore.Models;

    public interface IMusicStoreData
    {
        IRepository<Album> Albums { get; }

        IRepository<ApplicationUser> Artists { get; }

        IRepository<Country> Coutries { get; }

        IRepository<Producer> Producers { get; }

        IRepository<Song> Songs { get; } 

        void SaveChanges();
    }
}
