namespace MoviesSystem.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using MoviesSystem.Data.Models;

    public sealed class Configuration : DbMigrationsConfiguration<MoviesSystemDbContext>
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
                                     new Actor() { Name = "Jennifer Jason Leigh", BirthYear = 1962, Gender = Gender.Female},
                                     new Actor() { Name = "Gary Oldman", BirthYear = 1958, Gender = Gender.Male},
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
                                             LeadingFemaleRoleActor = actors[0]
                                         },
                                     new Movie()
                                         {
                                             Title = "Tinker Tailor Soldier Spy",
                                             Year = 2011,
                                             Studio = studios[1],
                                             LeadingMaleRoleActor = actors[1]
                                         },
                                 };
                context.Studios.AddOrUpdate(studios.ToArray());
                context.Actors.AddOrUpdate(actors.ToArray());
                context.Movies.AddOrUpdate(movies.ToArray());
                context.SaveChanges();
            }
        }
    }
}