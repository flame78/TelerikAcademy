namespace Twitter.Web.ViewModels
{
    using System;
    using System.Linq.Expressions;

    using Twitter.Data.Models;

    public class TagViewModel
    {
        public string Name { get; set; }

        public static Expression<Func<Tag, TagViewModel>> FromTag
        {
            get
            {
                return h => new TagViewModel() { Name = h.Name };
            }
        }
    }
}