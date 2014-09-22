namespace Exam.WebServices.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using Exam.DAL;
    using Exam.Models;
    using Exam.WebServices.Models;

    using Microsoft.AspNet.Identity;

    [Authorize]
    public class ArticlesController : BaseApiController
    {
        private const int PageSize = 2;

        public ArticlesController() : this(new ExamData()) { }

        public ArticlesController(IExamData data) : base(data) { }

        // api/articles/{articleID}/comments
        [HttpPost]
        [Authorize]
        public IHttpActionResult Comments(int id, CommentModel comment)
        {
            var article = this.Data.Articles.Find(id);
            var author = this.Data.User.Find(User.Identity.GetUserId());

            if (!this.ModelState.IsValid || article == null)
            {
                return this.BadRequest();
            }

            var newComment = new Comment
            {
                 Content = comment.Content,
                 ApplicationUser = author,
                 ArticleId = id,
            };


            article.Comments.Add(newComment);
            this.Data.SaveChanges();

            return this.Ok();

        }
        [HttpPost]
        public IHttpActionResult Post(ArticleModel articleModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var category = this.GetCategory(articleModel);
            var tags = this.GetTags(articleModel);
            var newArticle = new Article
                                       {
                                           Title = articleModel.Title,
                                           CategoryId = category.Id,
                                           Content = articleModel.Content,
                                           Tags = tags
                                       };
            this.Data.Articles.Add(newArticle);
            this.Data.SaveChanges();

            articleModel.Id = newArticle.Id;
            articleModel.DateCreated = newArticle.DateCreated;

            return this.Ok(articleModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult Get()
        {
            return GetByPage(0);
        }

        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult Details(int id)
        {
            var article = this.Data.Articles.All().FirstOrDefault(a => a.Id == id);
            if (article == null)
            {
                return this.NotFound();
            }

            return this.Ok(new ArticleDetailModel(article));
        }

        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult Get(int page)
        {
           return GetByPage(page);
        }
 
        // api/articles?category=[categoryName]
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult Get(string category)
        {
            return this.GetByCategory(category, 0);
        }

        //   api/articles?category=[categoryName]&page=P
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult Get(string category, int page)
        {
            return this.GetByCategory(category, page);
        }

        private IHttpActionResult GetByPage(int page)
        {
            return this.Ok(this.Data.Articles.All().OrderByDescending(a => a.DateCreated).Skip(page * PageSize).Take(PageSize).Select(ArticleModel.FromArticle));
        }

        private IHttpActionResult GetByCategory(string category, int page)
        {
            var existingCategory = this.Data.Categories.All().FirstOrDefault(c => c.Name == category);
            if (existingCategory == null)
            {
                return this.NotFound();
            }

            return this.Ok(this.Data.Articles.All().Where(a => a.CategoryId == existingCategory.Id).OrderByDescending(a => a.DateCreated).Skip(PageSize * page).Take(PageSize).Select(ArticleModel.FromArticle));

        }

        private ICollection<Tag> GetTags(ArticleModel articleModel)
        {
            var tags = new HashSet<Tag>();
            foreach (var tag in articleModel.Tags)
            {
                tags.Add(this.Data.Tags.All().FirstOrDefault(t => t.Name == tag) ?? this.Data.Tags.Add(new Tag { Name = tag }));
            }


            return tags;
        }


        private Category GetCategory(ArticleModel model)
        {
            var categoryName = model.Category;

            var storedCategory = this.Data.Categories.All().FirstOrDefault(c => c.Name == categoryName)
                                 ?? this.Data.Categories.Add(new Category { Name = categoryName });


            return storedCategory;
        }
    }
}