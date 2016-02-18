namespace LibrarySystem.Services.Data
{
    using System;
    using System.Linq;

    using LibrarySystem.Data.Common;
    using LibrarySystem.Data.Models;
    using LibrarySystem.Services.Web;

    public class BookService : IBooksService
    {
        private readonly IDbRepository<Book> books;
        private readonly IIdentifierProvider identifierProvider;

        public BookService(IDbRepository<Book> books, IIdentifierProvider identifierProvider)
        {
            this.books = books;
            this.identifierProvider = identifierProvider;
        }

        public Book GetById(int id)
        {
            var book = this.books.GetById(id);
            return book;
        }

        public IQueryable<Book> GetAll()
        {
            return this.books.All();
        }

        public Book Add(Book book)
        {
            this.books.Add(book);
            this.books.Save();

            return book;
        }

        public Book UpdateById(int id, Book updateBook)
        {
            var book = this.books.GetById(id);

            book.CategoryId = updateBook.CategoryId;
            book.Title = updateBook.Title;
            book.Description = updateBook.Description;

            this.books.Save();

            return book;
        }

        public void RemoveById(int id)
        {
            var book = this.books.GetById(id);
            this.books.Delete(book);
            this.books.Save();
        }
    }
}
