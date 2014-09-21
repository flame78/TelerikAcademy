namespace MusicStore.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Album
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Title { get; set; }

        [Required]
        public DateTime Year { get; set; }

        [Required]
        public virtual  Producer Producer { get; set; }

        [Required]
        public virtual ApplicationUser Artist { get; set; }
    }

}
