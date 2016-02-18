namespace LibrarySystem.Web.Controllers
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;

    using LibrarySystem.Services.Data;
    using LibrarySystem.Web.Infrastructure.Mapping;
    using LibrarySystem.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IBooksService books;

        private readonly ICategoriesService categories;

        public HomeController(IBooksService books, ICategoriesService categories)
        {
            this.books = books;
            this.categories = categories;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public JsonResult Tree(string id)
        {
            int idInt;
            int.TryParse(id, out idInt);

            if (id != null)
            {
                if (id.StartsWith("book"))
                {
                    int.TryParse(id.Substring(4), out idInt);
                    var description = new[]
                                          {
                                              new
                                                  {
                                                      id = "description" + idInt,
                                                      Name ="Description: "+ this.books.GetById(idInt).Description,
                                                      hasChildren = false
                                                  }
                                          };
                    return this.Json(description, JsonRequestBehavior.AllowGet);
                }
                else if (id.StartsWith("category"))
                {
                    int.TryParse(id.Substring(8), out idInt);
                    var booksTree =
                        this.books.GetAll()
                            .Where(b => b.CategoryId == idInt)
                            .Select(
                                b =>
                                new
                                {
                                    id = "book" + b.Id,
                                    Name = "Book: <a href = '/BookDetails/" + b.Id + "'>" + b.Title + "</a>",
                                    hasChildren = b.Description != null
                                });
                    return this.Json(booksTree, JsonRequestBehavior.AllowGet);
                }
            }

            var categoriesTree =
                this.categories.GetAll()
                    .Select(c => new { id = "category" + c.Id, Name ="Category: "+ c.Name, hasChildren = c.Books.Any() });
            return this.Json(categoriesTree, JsonRequestBehavior.AllowGet);
        }
    }
}