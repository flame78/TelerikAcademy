namespace MoviesSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Actor
    {
        public Actor()
        {
            this.Movies = new HashSet<Movie>();
        }

        [Key]
        public int Id { get; set; }

        [MinLength(2)]
        [MaxLength(50)]
        [Index(IsUnique = true)]
        [DisplayName("Actor name")]
        public string Name { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [Range(1900, 2100)]
        [DisplayName("Year of birth")]
        public int BirthYear { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}