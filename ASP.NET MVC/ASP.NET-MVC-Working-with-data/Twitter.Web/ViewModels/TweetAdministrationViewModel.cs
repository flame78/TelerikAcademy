using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    using Twitter.Data.Models;

    public class TweetAdministrationViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Tweet content")]
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Content { get; set; }

        public string UserId { get; set; }

        public string Username { get; set; }

        public DateTime CreationDate { get; set; }

        public ICollection<TagViewModel> HashTags { get; set; }

        public static Expression<Func<Tweet, TweetAdministrationViewModel>> FromTweet
        {
            get
            {
                return t => new TweetAdministrationViewModel()
                {
                    Id = t.Id,
                    Content = t.Content,
                    CreationDate = t.CreationDate,
                    UserId = t.AuthorId,
                    Username = t.Author.UserName,
                    HashTags = t.Tags.AsQueryable().Select(TagViewModel.FromTag).ToList()
                };
            }
        }
    }
}
