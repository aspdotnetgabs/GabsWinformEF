using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GabsWinformEF.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
    }

    public static class BookRepository
    {
        private static MyDbContext _db = new MyDbContext();

        public static List<Book> GetAll()
        {
            var books = _db.Books.ToList();
            return books;
        }

        public static Book GetById(int Id)
        {
            var book = _db.Books.Find(Id);
            return book;
        }

        public static int Add(Book book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
            return book.Id;
        }

        public static Book Update(Book book)
        {
            var b = _db.Books.Find(book.Id);
            b.ISBN = book.ISBN;
            b.Title = book.Title;
            _db.Entry(b).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
            return b;
        }

        public static bool Delete(int Id)
        {
            var book = _db.Books.Find(Id);
            if (book != null)
            {
                _db.Books.Remove(book);
                _db.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}
