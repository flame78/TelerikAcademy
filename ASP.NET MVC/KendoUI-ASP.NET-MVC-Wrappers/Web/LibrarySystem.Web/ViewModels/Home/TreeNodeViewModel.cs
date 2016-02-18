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

    public class TreeNodeViewModel : IMapFrom<Category>, IMapFrom<Book>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public ICollection<TreeNodeViewModel> Books { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Category, TreeNodeViewModel>()
              .ForMember(x => x.Books, opt => opt.MapFrom(x => x.Books));

            configuration.CreateMap<Book, TreeNodeViewModel>()
              .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Title));

        }
    }
}
