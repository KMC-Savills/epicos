using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpicOS.Managers;
using EpicOS.Models.Entities;
using EpicOS.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EpicOS.Helpers;
using System.Data.SqlClient;

namespace EpicOS.Controllers
{
    public class AddBookController : Controller
    {
        public IActionResult Index()
        {
            BookManager manager = new BookManager();
            return View(manager.GetAll());
        }
        [HttpGet]
        public IActionResult InsertBook()
        {
            return View();
        }
        [HttpPost]
        public IActionResult InsertBook(Book book)
        {
            //FieldTransformer transform = new FieldTransformer();
            //Book newBook = new Book();
            //newBook.UserID = transform.ToInt(book.UserID);
            //newBook.WorkpointID = transform.ToInt(book.WorkpointID);
            //newBook.FloorID = transform.ToInt(book.FloorID);
            //newBook.OfficeID = transform.ToInt(book.OfficeID);
            //newBook.CheckIn = transform.ToDateTime(book.CheckIn);
            //newBook.CheckOut = transform.ToDateTime(book.CheckOut);
            //newBook.IsActive = transform.ToBool(book.IsActive);
            //newBook.IsDeleted = transform.ToBool(book.IsDeleted);

            BookManager bookManager = new BookManager();
            bookManager.Insert(book);

            CacheNinja ninja = new CacheNinja();
            ninja.ClearCache("Book_GetAll");
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditBook(int id)
        {
            
            BookRepository bookRepository = new BookRepository();
            Book book = bookRepository.GetByID(id);

            BookManager manager = new BookManager();
            manager.Update(book);   

            return View(book);
        }

        // AddBook/EditBook
        [HttpPost]
        public IActionResult EditBook(Book book)
        {
            //FieldTransformer transform = new FieldTransformer();
            //BookRepository bookRepository = new BookRepository();
            //Book newBook = bookRepository.GetByID(book.ID);
            //newBook.UserID = transform.ToInt(book.UserID);
            //newBook.WorkpointID = transform.ToInt(book.WorkpointID);
            //newBook.FloorID = transform.ToInt(book.FloorID);
            //newBook.OfficeID = transform.ToInt(book.OfficeID);
            //newBook.CheckIn = transform.ToDateTime(book.CheckIn);
            //newBook.CheckOut = transform.ToDateTime(book.CheckOut);
            //newBook.IsActive = transform.ToBool(book.IsActive);
            //newBook.IsDeleted = transform.ToBool(book.IsDeleted);

            BookManager manager = new BookManager();
            manager.Update(book);

            CacheNinja ninja = new CacheNinja();
            ninja.ClearCache("Book_GetAll");
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            BookManager manager = new BookManager();
            manager.Delete(id);

            return RedirectToAction("Index");

        }
    }
}