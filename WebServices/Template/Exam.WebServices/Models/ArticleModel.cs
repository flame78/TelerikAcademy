namespace Exam.WebServices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;

    using Exam.Models;

    public class ArticleModel
    {
        public ArticleModel()
        {
            this.Tags = new HashSet<string>();
      //      this.DateCreated = DateTime.Now;
        }

        public static Expression<Func<Article, ArticleModel>> FromArticle
        {
            get
            {
                return
                    a =>
                    new ArticleModel
                        {
                            Id = a.Id,
                            Title = a.Title,
                            Content = a.Content,
                            DateCreated = a.DateCreated,
                            Category = a.Category.Name,
                            Tags = a.Tags.Select(t => t.Name).ToList()
                        };
            }
        }

        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Title { get; set; }

        [Required]
        [MinLength(5)]
        public string Content { get; set; }

        [Required]
        [MinLength(3)]
        public string Category { get; set; }

        public DateTime DateCreated { get; set; }

        [Required]
        public ICollection<string> Tags { get; set; }
    }
}