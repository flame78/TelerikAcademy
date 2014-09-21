namespace MusicStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Country
    {
        private ICollection<ApplicationUser> artists;

        public Country()
        {
            this.artists = new HashSet<ApplicationUser>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }

        public virtual ICollection<ApplicationUser> Artists
        {
            get
            {
                return this.artists;
            }
            set
            {
                this.artists = value;
            }
        }
    }
}
