using System.ComponentModel.DataAnnotations;

namespace MoviesInformationalSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Range(1900,2100)]
        public int Year { get; set; }

        public int StudioId { get; set; }

        public virtual Studio Studio { get; set; }

        public int? LeadingMaleRoleId { get; set; }

        [ForeignKey("LeadingMaleRoleId")]
        public virtual Actor LeadingMaleRole { get; set; }

        public int? LeadingFemaleRoleId { get; set; }

        [ForeignKey("LeadingFemaleRoleId")]
        public virtual Actor LeadingFemaleRole { get; set; }

    }
}
