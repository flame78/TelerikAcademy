namespace MusicStore.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Song
    {
        private ICollection<Album> albums;

        public Song()
        {
            this.albums = new HashSet<Album>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DataType Year { get; set; }

        [Required]
        public virtual ApplicationUser Artist { get; set; }

        [Required]
        public virtual ICollection<Album> Albums
        {
            get
            {
                return this.albums;
            }

            set
            {
                this.albums = value;
            }
        }


    }
}
