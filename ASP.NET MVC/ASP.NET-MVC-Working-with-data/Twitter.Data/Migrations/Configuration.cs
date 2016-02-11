namespace Twitter.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Twitter.Data.Models;

    public sealed class Configuration : DbMigrationsConfiguration<Twitter.Data.TwitterDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TwitterDbContext context)
        {
            if (context.Tweets.Any())
            {
                return;
            }

            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);
            var role = new IdentityRole { Name = "Administrator" };

            manager.Create(role);

            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);
            userManager.PasswordValidator = new PasswordValidator
                                                {
                                                    RequiredLength = 1,
                                                    RequireNonLetterOrDigit = false,
                                                    RequireDigit = false,
                                                    RequireLowercase = false,
                                                    RequireUppercase = false,
                                                };
            var adminUser = new User { UserName = "admin" };

            userManager.Create(adminUser, "_");
            userManager.AddToRole(adminUser.Id, "Administrator");

            var tags = new List<Tag>()
                           {
                               new Tag() { Name = "#Use" },
                               new Tag() { Name = "#for" },
                               new Tag() { Name = "#tag" },
                               new Tag() { Name = "#fail" },
                               new Tag() { Name = "#all" },
                               new Tag() { Name = "#and" },
                               new Tag() { Name = "#data" },
                           };
            var tweets = new List<Tweet>()
                             {
                                 new Tweet()
                                     {
                                         Author = adminUser,
                                         Content = "#Use \"admin\" for administration!"
                                     },
                                 new Tweet()
                                     {
                                         Author = adminUser,
                                         Content =
                                             "* Have Kendo UI Grid-based administration #for tweets (with paging, sorting, filtering, etv.)"
                                     },
                                 new Tweet()
                                     {
                                         Author = adminUser,
                                         Content =
                                             "Have administration #for the tweets using ASP.NET scaffolding (admins only)"
                                     },
                                 new Tweet()
                                     {
                                         Author = adminUser,
                                         Content =
                                             "List all tweets containing specific tag (#fail) and use 15 minutes caching for each #tag"
                                     },
                                 new Tweet()
                                     {
                                         Author = adminUser,
                                         Content =
                                             "List #all tweets for specific user in his profile"
                                     },
                                 new Tweet()
                                     {
                                         Author = adminUser,
                                         Content = "Have users #and administrators"
                                     },
                                 new Tweet()
                                     {
                                         Author = adminUser,
                                         Content =
                                             "Create a simple ASP.NET MVC Twitter-like system using #data validation, Entity Framework, repository pattern and unit of work pattern. Your system should:"
                                     }
                             };

            tweets[0].Tags.Add(tags[0]);
            tweets[1].Tags.Add(tags[1]);
            tweets[2].Tags.Add(tags[1]);
            tweets[3].Tags.Add(tags[2]);
            tweets[3].Tags.Add(tags[3]);
            tweets[4].Tags.Add(tags[4]);
            tweets[5].Tags.Add(tags[5]);
            tweets[6].Tags.Add(tags[6]);

            context.Tweets.AddOrUpdate(tweets.ToArray());

            context.SaveChanges();
        }
    }
}