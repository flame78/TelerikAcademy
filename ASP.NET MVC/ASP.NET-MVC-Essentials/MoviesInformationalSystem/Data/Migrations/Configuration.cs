namespace MoviesInformationalSystem.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using MoviesInformationalSystem.Data.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MoviesSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MoviesSystemDbContext context)
        {
            if (!context.Movies.Any())
            {
                var actors = new List<Actor>()
                                 {
                                     new Actor() { Name = "Jennifer Jason Leigh", BirthYear = 1962 },
                                     new Actor() { Name = "Gary Oldman", BirthYear = 1958 },
                                 };

                var studios = new List<Studio>()
                                  {
                                      new Studio()
                                          {
                                              Name = "Miramax",
                                              Address =
                                                  "2540 Colorado Avenue, Suite 100E, Santa Monica, California 90404"
                                          },
                                      new Studio()
                                          {
                                              Name = "Studio Canal",
                                              Address =
                                                  "1 Place du Spectacle, 92863 Issy-Les-Moulineaux Cedex 9"
                                          },
                                  };

                var movies = new List<Movie>()
                                 {
                                     new Movie()
                                         {
                                             Title = "Georgia",
                                             Year = 1995,
                                             Studio = studios[0],
                                             LeadingFemaleRole = actors[0]
                                         },
                                     new Movie()
                                         {
                                             Title = "Tinker Tailor Soldier Spy",
                                             Year = 2011,
                                             Studio = studios[1],
                                             LeadingMaleRole = actors[1]
                                         },
                                 };

                context.Movies.AddOrUpdate(movies.ToArray());
                context.SaveChanges();
            }
        }
    }
}