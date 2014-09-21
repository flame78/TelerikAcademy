namespace MusicStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Producer
    {
        private ICollection<Album> albums;

        public Producer ()
        {
            this.albums = new HashSet<Album>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }

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
