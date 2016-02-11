namespace Twitter.Data.Uow
{
    using System;

    using Twitter.Data.Models;

    public interface ITwitterUow : IDisposable
    {
        IGenericRepository<User, string> Users { get; }

        IGenericRepository<Tweet, int> Tweets { get; }

        IGenericRepository<Tag, string> Tags { get; }

        int Save();
    }
}