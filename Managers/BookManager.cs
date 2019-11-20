using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpicOS.Helpers;
using EpicOS.Models.Entities;
using EpicOS.Repository;
namespace EpicOS.Managers
{
    public class BookManager : BaseManager
    {
        private BookRepository book;

        public BookManager()
        {
            this.book = new BookRepository();
        }
        public List<Book> GetAll()
        {
            List<Book> books = cacheNinja.cache["Book_GetAll"] as List<Book>;
            if (books == null)
            {
                books = book.GetAll();
                cacheNinja.cache.Set("Book_GetAll", books, cacheNinja.cacheExpiry);
            }
            return books;
        }
        public Book GetByID(int id)
        {
            return GetAll().FirstOrDefault(e => e.ID.Equals(id));
        }

        public Result Insert(Book parameter)
        {
            return book.Insert(parameter);
        }

        public Result Update(Book parameter)
        {
            return book.Update(parameter);
        }
    }
}
