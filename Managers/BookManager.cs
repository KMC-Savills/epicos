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
        private BookRepository bookRepo;

        public BookManager()
        {
            this.bookRepo = new BookRepository();
        }
        public List<Book> GetAll()
        {
            List<Book> books = cacheNinja.cache["Book_GetAll"] as List<Book>;
            if (books == null)
            {
                books = bookRepo.GetAll();
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
            return bookRepo.Insert(parameter);
        }

        public Result Update(Book parameter)
        {
            return bookRepo.Update(parameter);
        }
        public Result Delete(int id)
        {
            Book item = bookRepo.GetByID(id);
            item.IsDeleted = true;
            Result sub = bookRepo.Update(item);
            if (sub.IsSuccess)
            {
                cacheNinja.ClearCache("Book_GetAll");
            }
            return sub;
        }
    }
}
