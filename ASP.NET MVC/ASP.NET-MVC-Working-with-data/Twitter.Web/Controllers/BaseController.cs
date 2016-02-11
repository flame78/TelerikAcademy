using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Web.Controllers
{
    using System.Text.RegularExpressions;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using Ninject;

    using Twitter.Data.Models;
    using Twitter.Data.Uow;

    public class BaseController : Controller
    {
        protected string UserId
        {
            get
            {
                return User.Identity.GetUserId();
            }
        }

        [Inject]
        public ITwitterUow TwitterUow { get; set; }

        protected void AddTags(Tweet tweet)
        {
            var tags = GetTags(tweet.Content);
            foreach (var tag in tags)
            {
                tweet.Tags.Add(CreateOrGetTag(tag));
            }
        }

        private List<string> GetTags(string tweet)
        {
            List<string> tags = new List<string>();

            foreach (Match match in Regex.Matches(tweet, @"#[-\w+]+"))
            {
                tags.Add(match.Value);
            }

            return tags;
        }

        private Tag CreateOrGetTag(string tag)
        {
            var existingHashTag = this.TwitterUow.Tags.All().FirstOrDefault(h => h.Name == tag);
            if (existingHashTag != null)
            {
                return existingHashTag;
            }

            var newTag = new Tag() { Name = tag };

            return newTag;
        }
    }
}
