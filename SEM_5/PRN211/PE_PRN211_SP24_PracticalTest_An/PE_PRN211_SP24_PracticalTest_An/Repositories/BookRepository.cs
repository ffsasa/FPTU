using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BookRepository
    {
        private BookManagementDbContext _context;
        public List<Book> GetBooks()
        {
            _context = new ();
            return _context.Books.ToList();
        }

        //Cập nhật 1 cuốn sách có sẵn
        public void UpdateBook(Book book)
        {
            _context = new();
            _context.Books.Update(book); //Tạo câu SQL
            _context.SaveChanges(); //Run câu SQL
        }

        public void AddBook(Book book)
        {
            _context = new();
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void DeleteBook(Book book)
        {
            _context = new();
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
