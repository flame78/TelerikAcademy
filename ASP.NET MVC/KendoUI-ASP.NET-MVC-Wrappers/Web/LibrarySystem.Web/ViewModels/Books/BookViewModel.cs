namespace LibrarySystem.Web.ViewModels.Books
{
    using System.ComponentModel.DataAnnotations;

    using LibrarySystem.Data.Models;
    using LibrarySystem.Web.Infrastructure.Mapping;

    public class BookViewModel : IMapFrom<Book>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }

        public string WebSite { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
