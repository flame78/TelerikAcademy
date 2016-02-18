namespace LibrarySystem.Web.Controllers
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.DynamicData;
    using System.Web.Mvc;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using LibrarySystem.Data.Models;
    using LibrarySystem.Services.Data;
    using LibrarySystem.Services.Web;
    using LibrarySystem.Web.Infrastructure.Mapping;
    using LibrarySystem.Web.ViewModels.Books;
    using LibrarySystem.Web.ViewModels.Home;

    public class AdministrationGridController : Controller
    {
        private IBooksService books;

        private ICacheService cache;

        private ICategoriesService categories;

        public AdministrationGridController(IBooksService books, ICategoriesService categories, ICacheService cache)
        {
            this.books = books;
            this.categories = categories;
            this.cache = cache;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Books_Read([DataSourceRequest] DataSourceRequest request)
        {
            var result = this.books.GetAll().To<BookViewModel>().ToDataSourceResult(request);

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Books_Create([DataSourceRequest] DataSourceRequest request, BookViewModel book)
        {
            if (!this.categories.GetAll().Any(c => c.Id == book.CategoryId))
            {
                this.ModelState.AddModelError("CategoryId", "Please select category");
            }

            if (this.ModelState.IsValid )
            {
                var newBook = new Book
                                  {
                                      Title = book.Title,
                                      Description = book.Description,
                                      CategoryId = book.CategoryId
                                  };

               ;
                this.books.Add(newBook);

                book = this.books.GetAll().To<BookViewModel>().Where(b => b.Id== newBook.Id).FirstOrDefault();
            }

            return this.Json(new[] { book }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Books_Update([DataSourceRequest] DataSourceRequest request, BookViewModel book)
        {
            if (this.ModelState.IsValid)
            {
                var bookToUpdate = this.books.GetById(book.Id);
                bookToUpdate.Title = book.Title;
                bookToUpdate.Description = book.Description;
                bookToUpdate.CategoryId = book.CategoryId;

                book = new[] { this.books.UpdateById(book.Id, bookToUpdate)}.AsQueryable().To<BookViewModel>().FirstOrDefault();

            }

            return this.Json(new[] { book }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Books_Destroy([DataSourceRequest] DataSourceRequest request, BookViewModel book)
        {
            if (this.ModelState.IsValid)
            {
                this.books.RemoveById(book.Id);
            }

            return this.Json(new[] { book }.ToDataSourceResult(request, this.ModelState));
        }

        public JsonResult GetCategories()
        {
            var allCategories = this.cache.Get<ICollection<object>>(
                "Categories",
                this.GetCategoriesFunc,
                15 * 60);

            return this.Json(allCategories, JsonRequestBehavior.AllowGet);
        }

        private ICollection<object> GetCategoriesFunc()
        {
            var categories =
                this.categories.GetAll()
                    .OrderBy(c => c.Name)
                    .Select(c => new { Id = c.Id.ToString(), Name = c.Name })
                    .ToList();
            categories.Insert(0, new { Id = string.Empty, Name = "--- Select Category ---" });

            return categories.ToArray();
        }
    }
}