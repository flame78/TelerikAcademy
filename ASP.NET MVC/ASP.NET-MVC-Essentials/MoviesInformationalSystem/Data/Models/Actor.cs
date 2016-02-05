
namespace MoviesInformationalSystem.Data.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Actor
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Index("IX_Name", 1, IsUnique = true)]
        [DisplayName("Actor name")]
        public string Name { get; set; }

        [NotMapped]
        public int Age => DateTime.Now.Year - this.BirthYear;

        [Required]
        [Range(1900, 2100)]
        [DisplayName("Year of birth")]
        public int BirthYear { get; set; }
    }
}