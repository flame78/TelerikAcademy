namespace LibrarySystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using LibrarySystem.Services.Data;
    using LibrarySystem.Web.Infrastructure.Mapping;
    using LibrarySystem.Web.ViewModels.Books;
    using LibrarySystem.Web.ViewModels.Home;

    [Authorize]
    public class BooksController : BaseController
    {
        private readonly IBooksService books;

        public BooksController(IBooksService books)
        {
            this.books = books;
        }

        public ActionResult BookDetails(int id)
        {
            var book = this.Mapper.Map<BookViewModel>(this.books.GetById(id));

            return this.View(book);
        }

        [HttpPost]
        public ActionResult Search(string q)
        {
            if (q == null)
            {
                return this.RedirectToAction("Index", "Home");
            }

            this.ViewBag.Query = q;

            q = q.ToLower();

            var books =
                this.books.GetAll()
                    .Where(b => b.Title.ToLower().Contains(q) || b.Author.ToLower().Contains(q))
                    .To<BookSearchViewModel>()
                    .ToArray();
            return this.View(books);
        }

        public JsonResult GetBooks(string text)
        {
            var results = this.books.GetAll()
                    .Where(b => b.Title.ToLower().Contains(text.ToLower()))
                    .Select(b => new { Id = b.Id, Text = b.Title })
                    .ToList();

            results.AddRange(this.books.GetAll()
                    .Where(b => b.Author.Contains(text.ToLower()))
                    .Select(b => new { Id = b.Id, Text = b.Author })
                    .ToList());

            return this.Json(results, JsonRequestBehavior.AllowGet);
        }
    }
}