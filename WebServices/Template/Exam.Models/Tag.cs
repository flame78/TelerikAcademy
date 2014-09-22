using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Tag
    {
        private ICollection<Article> articles;

        public Tag()
        {
            this.articles = new HashSet<Article>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        public virtual ICollection<Article> Articles
        {
            get
            {
                return this.articles;
            }
            set
            {
                this.articles = value;
            }
        }
    }
}
