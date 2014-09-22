namespace Exam.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Article
    {
        private ICollection<Tag> tags;

        public Article()
        {
            this.tags = new HashSet<Tag>();
            this.DateCreated = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Title { get; set; }

        [Required]
        [MinLength(5)]
        public string Content { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public DateTime DateCreated { get; private set; }

        [Required]
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
