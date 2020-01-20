using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpicOS.Helpers;
using EpicOS.Managers;
using EpicOS.Models.Entities;
using EpicOS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EpicOS.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            UserManager userManager = new UserManager();
            return View(userManager.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User user)
        {

            UserManager userManager = new UserManager();
            userManager.Insert(user);
            CacheNinja ninja = new CacheNinja();
            ninja.ClearCache("User_GetAll");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
           
            UserManager userManager = new UserManager();
            var getUsers = userManager.GetByID(id);
            return View(getUsers);

        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            UserManager userManager = new UserManager();
            userManager.Update(user);
            CacheNinja cache = new CacheNinja();
            cache.ClearCache("User_GetAll");
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            UserManager userManager = new UserManager();
            userManager.Delete(id);
            CacheNinja cache = new CacheNinja();
            cache.ClearCache("User_GetAll");
            return RedirectToAction("Index");
        }
    }
}