namespace MoviesInformationalSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    using MoviesInformationalSystem.Data.Models;

    public class MovieViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [Range(1900, 2100)]
        public int Year { get; set; }

        public string LeadingMaleRoleName { get; set; }

        public string LeadingFemaleRoleName { get; set; }
    }
}