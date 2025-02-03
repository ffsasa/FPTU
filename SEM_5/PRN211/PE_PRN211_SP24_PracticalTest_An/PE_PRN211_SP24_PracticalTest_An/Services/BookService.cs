using Repositories;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookService
    {
        private BookRepository repository = new BookRepository();
        public List<Book> GetAllBooks()
        {
            return repository.GetBooks();
        }

        public void AddBook(Book book)
        {
            repository.AddBook(book);
        }

        public void DeleteBook(Book book)
        {
            repository.DeleteBook(book);
        }

        public void UpdateBook(Book book)
        {
            repository.UpdateBook(book);
        }
    }
}
