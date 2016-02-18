namespace LibrarySystem.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using LibrarySystem.Data.Models;
    using LibrarySystem.Web.Infrastructure.Mapping;
    using LibrarySystem.Web.ViewModels.Books;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public string Name { get; set; }

        public ICollection<BookViewModel> Books { get; set; } 
    }
}
