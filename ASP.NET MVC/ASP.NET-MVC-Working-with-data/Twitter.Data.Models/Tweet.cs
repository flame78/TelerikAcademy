namespace Twitter.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tweet
    {
        public Tweet()
        {
            this.Tags = new HashSet<Tag>();
            this.CreationDate = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreationDate { get;private set; }  

        public virtual ICollection<Tag> Tags { get; set; }
    }
}