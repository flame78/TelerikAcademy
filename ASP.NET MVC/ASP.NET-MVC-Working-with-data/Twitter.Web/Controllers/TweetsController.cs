namespace Twitter.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Web.Mvc;

    using AutoMapper;

    using Microsoft.Ajax.Utilities;

    using Twitter.Data.Models;
    using Twitter.Data.Uow;
    using Twitter.Web.Infrastructure.Mapping;
    using Twitter.Web.ViewModels;

    public class TweetsController : BaseController, IDisposable
    {

        public ActionResult Index()
        {
            var tweets =
                TwitterUow.Tweets.All().OrderByDescending(t => t.CreationDate).Take(15).To<TweetViewModel>().ToList();
            return View(tweets);
        }

        [Authorize]
        public ActionResult ByUser()
        {
            return
                View(
                    TwitterUow.Users.GetById(UserId)
                        .Tweets.OrderByDescending(t => t.CreationDate)
                        .Take(15)
                        .AsQueryable()
                        .To<TweetViewModel>()
                        .ToList());
        }

        public ActionResult ByAuthor(string id)
        {
            List<TweetViewModel> tweets;
            try
            {
                var user = TwitterUow.Users.All().FirstOrDefault(u => u.UserName == id);

                tweets = user.Tweets.OrderByDescending(t => t.CreationDate)
                    .Take(15)
                    .AsQueryable()
                    .To<TweetViewModel>()
                    .ToList();
                ViewBag.Author = user.UserName;
            }
            catch (Exception)
            {
                TempData["Error"] = "Incorrect Auhtor";
                return RedirectToAction("Index");
            }
            return this.View(tweets);
        }

        [OutputCache(Duration = 15 * 60, VaryByParam = "id")]
        public ActionResult ByTag(string id)
        {
            List<TweetViewModel> tweets;
            try
            {
                tweets =
                TwitterUow.Tags.GetById(id)
                    .Tweets.OrderByDescending(t => t.CreationDate)
                    .Take(15)
                    .AsQueryable()
                    .To<TweetViewModel>()
                    .ToList();
            }
            catch (Exception)
            {
                TempData["Error"] = "Incorect Tag!";
                return RedirectToAction("Index");
            }

            ViewBag.Tag = id;
            return this.View(tweets);
        }

        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult New(TweetViewModel tweetVM)
        {

            if (ModelState.IsValid)
            {
                var tweet = new Tweet()
                {
                    Content = tweetVM.Content,
                    AuthorId = this.UserId
                };
                AddTags(tweet);
                TwitterUow.Tweets.Add(tweet);
                TwitterUow.Save();
            }
            else
            {
                foreach (var item in ModelState.Values)
                {
                    foreach (var er in item.Errors)
                    {
                        TempData["Error"] += er.ErrorMessage;
                    }
                }
            }
            return RedirectToAction("Index");
        }


    }
}