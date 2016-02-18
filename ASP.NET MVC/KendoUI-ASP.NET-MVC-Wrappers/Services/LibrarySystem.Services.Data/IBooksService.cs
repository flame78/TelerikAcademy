namespace LibrarySystem.Services.Data
{
    using System.Linq;

    using LibrarySystem.Data.Models;

    public interface IBooksService
    {
        IQueryable<Book> GetAll();

        Book GetById(int id);

        Book Add(Book book);

        Book UpdateById(int id, Book updateBook);

        void RemoveById(int id);
    }
}
