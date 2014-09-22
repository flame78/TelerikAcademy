using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.WebServices.Models
{
    using Exam.Models;

    public class ArticleDetailModel : ArticleModel
    {

        public ArticleDetailModel(Article article)
        {
            this.Comments = new List<CommentModel>();
            this.Id = article.Id;
            this.Title = article.Title;
            this.Category = article.Category.Name;
            this.DateCreated = article.DateCreated;
            this.Tags = article.Tags.Select(t => t.Name).ToList();
            foreach (var comment  in article.Comments)
            {
                this.Comments.Add(
                    new CommentModel
                        {
                            Id = comment.Id,
                            Content = comment.Content,
                            DateCreated = comment.DateCreated,
                            AuthorName = comment.ApplicationUser.UserName
                        });
            }
        }

        public List<CommentModel> Comments { get; set; }


    }

}
