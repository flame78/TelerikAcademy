namespace MoviesSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Movie
    {
        public Movie()
        {
            this.Actors = new HashSet<Actor>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Range(1900, 2100)]
        public int Year { get; set; }

        public int StudioId { get; set; }

        [ForeignKey("StudioId")]
        public virtual Studio Studio { get; set; }

        public int? LeadingMaleRoleActorId { get; set; }

        [ForeignKey("LeadingMaleRoleActorId")]
        public virtual Actor LeadingMaleRoleActor { get; set; }

        public int? LeadingFemaleRoleActorId { get; set; }

        [ForeignKey("LeadingFemaleRoleActorId")]
        public virtual Actor LeadingFemaleRoleActor { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }
    }
}