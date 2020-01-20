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
using EpicOS.Models.ViewModel;

namespace EpicOS.Controllers
{
    public class BookController : Controller
    {
        
        public IActionResult Index()    
        {
            BookManager manager = new BookManager();
            return View(manager.GetAll());
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View(BookDropdowns());
        }
        [HttpPost]
        public IActionResult Add(Book book)
        {
            BookManager bookManager = new BookManager();
            bookManager.Insert(book);

            CacheNinja ninja = new CacheNinja();
            ninja.ClearCache("Book_GetAll");
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            
            BookRepository bookRepository = new BookRepository();
            Book book = bookRepository.GetByID(id);
            return View(book);
        }

        // AddBook/EditBook
        [HttpPost]
        public IActionResult Edit(Book book)
        {
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
        public BookViewModel BookDropdowns(int id = 0)
        {
            DropDownManager ddManager = new DropDownManager();
            BookViewModel bookView = new BookViewModel();
            bookView.ListOfFloors = ddManager.FloorDropdown();
            bookView.ListOfOffices = ddManager.OfficeDropDown();
            bookView.ListOfWorkpoint = ddManager.WorkpointsDropdown();
            bookView.ListOfUsers = ddManager.UsersDropdown();
            return bookView;
        }
    }
}