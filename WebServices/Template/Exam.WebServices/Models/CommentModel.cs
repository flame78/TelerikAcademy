namespace Exam.WebServices.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

    using Exam.Models;

    public class CommentModel
    {
        //public CommentModel(Comment comment)
        //{
        //    this.Id = comment.Id;
        //    this.Content = comment.Content;
        //    this.DateCreated = comment.DateCreated;
        //    this.AuthorName = comment.ApplicationUser.Email;
        //}

        //public static Expression<Func<Comment, CommentModel>> FromComment
        //{
        //    get
        //    {
        //        return
        //            c =>
        //            new CommentModel
        //                {
        //                    Id = c.Id,
        //                    Content = c.Content,
        //                    DateCreated = c.DateCreated,
        //                    AuthorName = c.ApplicationUser.UserName
        //                };
        //    }
        //}

        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public string AuthorName { get; set; }
    }
}