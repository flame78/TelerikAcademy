namespace MoviesSystem.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    using MoviesSystem.Data.Models;
    using MoviesSystem.Web.Infrastructure.Mappings;

    public class MovieViewModel : IMapFrom<Movie>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [Range(1900, 2100)]
        public int Year { get; set; }

        public string StudioName { get; set; }
    }
}