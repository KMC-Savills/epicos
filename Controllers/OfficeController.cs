using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpicOS.Models.Entities;
using EpicOS.Managers;
using Microsoft.AspNetCore.Mvc;
using EpicOS.Repository;
using EpicOS.Helpers;

namespace EpicOS.Controllers
{
    public class OfficeController : Controller
    {
        public IActionResult Index()
        {
            OfficeManager manager = new OfficeManager();
            return View(manager.OfficeGetAll());
        }

        public IActionResult OfficeList()
        {
            OfficeManager manager = new OfficeManager();
            return View(manager.OfficeGetAll());
        }

        [HttpGet]
        public ActionResult GetOfficeId(string id)
        {
            ViewBag.CaseId = id;
            return View();
        }

        public ActionResult Details(int id)
        {
            OfficeRepository officeRepo = new OfficeRepository();
            Office office = officeRepo.OfficeGetByID(id);

            OfficeManager manager = new OfficeManager();
            manager.OfficeUpdate(office);
            return View(office);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateOffice(Office office)
        {
            OfficeManager manager = new OfficeManager();
            manager.OfficeInsert(office);

            CacheNinja cache = new CacheNinja();
            cache.ClearCache("Office_GetAll");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            OfficeRepository officeRepo = new OfficeRepository();
            Office office = officeRepo.OfficeGetByID(id);

            OfficeManager manager = new OfficeManager();
            manager.OfficeUpdate(office);
            return View(office);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Office office)
        {
            OfficeManager manager = new OfficeManager();
            manager.OfficeUpdate(office);

            CacheNinja cache = new CacheNinja();
            cache.ClearCache("Office_GetAll");

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            OfficeManager manager = new OfficeManager();
            manager.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}