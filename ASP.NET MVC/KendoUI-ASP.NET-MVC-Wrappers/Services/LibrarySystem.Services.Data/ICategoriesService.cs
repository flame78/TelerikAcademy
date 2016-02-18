namespace LibrarySystem.Services.Data
{
    using System.Linq;

    using LibrarySystem.Data.Models;

    public interface ICategoriesService
    {
        IQueryable<Category> GetAll();

        Category EnsureCategory(string name);
    }
}
