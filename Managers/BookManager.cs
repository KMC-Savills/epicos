using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpicOS.Helpers;
using EpicOS.Models.Entities;
using EpicOS.Models.ViewModel;
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
        public List<Workpoint> GetWorkpoints()
        {
            List<Workpoint> workpoints = cacheNinja.cache["Workpoint_GetAll"] as List<Workpoint>;
            DeviceManager deviceManager = new DeviceManager();
            if (workpoints == null)
            {
                workpoints = deviceManager.WorkpointGetAll();
                cacheNinja.cache.Set("Workpoint_GetAll", workpoints, cacheNinja.cacheExpiry);
            }
            return workpoints;
        }
        //public List<BookViewModel> BookExtendedGetAll()
        //{
        //    List<BookViewModel> bookViewModels = new List<BookViewModel>();
        //    List<Book> books = GetAll();
        //    List<Workpoint> workpoints = GetWorkpoints();
        //    foreach (Book book in books)
        //    {
        //        BookViewModel bookItems = new BookViewModel();
        //        bookItems.ID = book.ID;
        //        bookItems.UserID = book.UserID;
        //        bookItems.WorkpointID = book.WorkpointID;
        //        bookItems.FloorID = book.FloorID;
        //        bookItems.OfficeID = book.OfficeID;
        //        bookItems.CheckIn = book.CheckIn;
        //        bookItems.CheckOut = book.CheckOut;
        //        bookItems.IsActive = book.IsActive;
        //        bookItems.IsDeleted = book.IsDeleted;
        //        bookItems.ListOfWorkpoint = workpoints.First(item => item.ID.Equals(book.)).Name;
        //    }
        //}
    }
}
