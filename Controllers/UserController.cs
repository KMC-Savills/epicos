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
        private UserManager userManager = new UserManager();
        private CacheNinja cacheNinja = new CacheNinja();


        public IActionResult Index()
        {
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
            if (ModelState.IsValid)
            {
                userManager.Insert(user);
                cacheNinja.ClearCache("User_GetAll");
            }
            else
            {
                ViewBag.Message = "Something went wrong!";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(userManager.GetByID(id));
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                userManager.Update(user);
                cacheNinja.ClearCache("User_GetAll");
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            UserManager userManager = new UserManager();
            userManager.Delete(id);
            cacheNinja.ClearCache("User_GetAll");
            return RedirectToAction("Index");
        }
    }
}