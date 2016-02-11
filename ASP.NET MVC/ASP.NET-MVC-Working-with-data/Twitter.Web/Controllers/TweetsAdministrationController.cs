using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Web.Controllers
{
    using System.Web.Mvc;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using Twitter.Data.Models;
    using Twitter.Web.Infrastructure.Mapping;
    using Twitter.Web.ViewModels;

    [Authorize(Roles = "Administrator")]
    public class TweetsAdministrationController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult All([DataSourceRequest] DataSourceRequest request)
        {
            var tweets = this.TwitterUow.Tweets.All().Select(TweetAdministrationViewModel.FromTweet);

            return Json(tweets.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, TweetViewModel tweet)
        {
            if (tweet != null && ModelState.IsValid)
            {
                try
                {
                    TwitterUow.Tweets.DeleteById(tweet.Id);
                    TwitterUow.Save();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return Json(new[] { tweet }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update([DataSourceRequest] DataSourceRequest request, TweetViewModel tweet)
        {
            if (tweet != null && ModelState.IsValid)
            {
                var existingTweet = TwitterUow.Tweets.GetById(tweet.Id);

                existingTweet.Content = tweet.Content;

                TwitterUow.Save();

                existingTweet.Tags.Clear();

                AddTags(existingTweet);

                TwitterUow.Tweets.Update(existingTweet);
                TwitterUow.Save();
            }

            return Json(new[] { tweet }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}
