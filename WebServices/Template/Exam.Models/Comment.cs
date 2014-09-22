using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Comment
    {
        public Comment()
        {
            this.DateCreated = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime DateCreated { get; private set; }

        [Required]
        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
