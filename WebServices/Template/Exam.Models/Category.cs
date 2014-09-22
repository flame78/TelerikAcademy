using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        private ICollection<Article> articles; 
        public Category()
        {
            this.articles = new HashSet<Article>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Type { get; set; }

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
