namespace MoviesSystem.Web.Models
{
    using System.Collections.Generic;

    using AutoMapper;

    using MoviesSystem.Data.Models;
    using MoviesSystem.Web.Infrastructure.Mappings;

    public class MovieDetailedViewModel : MovieViewModel, IHaveCustomMappings
    {
        public string LeadingMaleRoleActorName { get; set; }

        public string LeadingFemaleRoleActorName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Movie, MovieDetailedViewModel>()
                .ForMember(m => m.LeadingFemaleRoleActorName, m => m.MapFrom(p => p.LeadingFemaleRoleActor.Name));

            configuration.CreateMap<Movie, MovieDetailedViewModel>()
                .ForMember(m => m.LeadingMaleRoleActorName, m => m.MapFrom(p => p.LeadingMaleRoleActor.Name));
        }
    }
}