namespace Twitter.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Twitter.Data.Models;

    public class TwitterDbContext : IdentityDbContext<User>
    {
        public TwitterDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static TwitterDbContext Create()
        {
            return new TwitterDbContext();
        }

        public IDbSet<Tweet> Tweets { get; set; }

        public IDbSet<Tag> Tags { get; set; }
    }
}