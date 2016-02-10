namespace MoviesSystem.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using MoviesSystem.Data.Models;
    using MoviesSystem.Web.Infrastructure.Mappings;

    public class ActorViewModel : IMapFrom<Actor>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [MinLength(2)]
        [MaxLength(50)]
        [Required]
        [Display(Name = "Actor Name")]
        public string Name { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [Range(1,200)]
        public int Age { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Actor, ActorViewModel>()
                .ForMember(p => p.Age, opt => opt.MapFrom(p => DateTime.Now.Year - p.BirthYear));

            configuration.CreateMap<ActorViewModel, Actor>()
                .ForMember(p => p.BirthYear, opt => opt.MapFrom(p => DateTime.Now.Year - p.Age));
        }
    }
}