namespace BullsAndCows.DAL
{
    using BullsAndCows.DAL.Repositories;
    using BullsAndCows.Models;

    public interface IBullsAndCowsData
    {
        IRepository<User> Users { get; }

        IRepository<Guess> Guesses { get; }

        IRepository<Game> Games { get; }

        void SaveChanges();
    }
}
