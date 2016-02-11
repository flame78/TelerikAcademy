namespace Twitter.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using Twitter.Data.Models;
    using Twitter.Web.Infrastructure.Mapping;

    public class TweetViewModel : IMapFrom<Tweet>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string AuthorName { get; set; }

        [Display(Name = "Tweet")]
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Content { get; set; }

        public DateTime CreationDate { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Tweet, TweetViewModel>()
                .ForMember(x => x.AuthorName, opt => opt.MapFrom(x => x.Author.UserName));
        }
    }
}