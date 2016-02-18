using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Web.ViewModels.Home
{
    using AutoMapper;

    using LibrarySystem.Data.Models;
    using LibrarySystem.Web.Infrastructure.Mapping;

    public class BookSearchViewModel : IMapFrom<Book>, IHaveCustomMappings
    {
        public string Url { get; set; }

        public string Title { get; set; }

        public string CategoryName { get; set; }

        public string Author { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Book, BookSearchViewModel>()
            .ForMember(x => x.Url, opt => opt.MapFrom(x => "/BookDetails/" + x.Id));
        }
    }
}
