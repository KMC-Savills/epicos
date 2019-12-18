using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpicOS.Models.Entities;
using EpicOS.Managers;
using Microsoft.AspNetCore.Mvc;
using EpicOS.Repository;
using EpicOS.Helpers;
using System.IO;
using Microsoft.AspNetCore.Http;
using EpicOS.Models.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EpicOS.Controllers
{
    public class OfficeController : Controller
    {
        public IActionResult Index()
        {
            OfficeManager manager = new OfficeManager();
            return View(manager.OfficeExtendedGetAll());
        }
        public void ReadyContextForView(int id = 0)
        {
            DropDownManager ddManager = new DropDownManager();
            OfficeManager officeManager = new OfficeManager();
            OfficeViewModel context = new OfficeViewModel();
            context.ListOfCities = ddManager.CityDropDown();
            ViewBag.Context = context;
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
        public ActionResult Add()
        {
            //return View();
            return View(DefaultValueListing());
        }

        [HttpPost]
        public ActionResult Add(Office office)
        {
            OfficeManager manager = new OfficeManager();
            manager.OfficeInsert(office);

            //LocationManager locationManager = new LocationManager();
            //locationManager.CityGetAll();

            CacheNinja cache = new CacheNinja();
            cache.ClearCache("Office_GetAll");
            cache.ClearCache("Workpoint_GetAll");
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            OfficeManager manager = new OfficeManager();
            var model = manager.OfficeGetByID(id);
            ReadyContextForView(id);
            return View(model);
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
        public OfficeViewModel DefaultValueListing()
        {
            var defaultDate = DateTime.UtcNow;
            OfficeViewModel model = new OfficeViewModel();
            model.Latitude = 14.5477349;
            model.Longitude = 121.04621500000007;
            DropDownManager dropDownManager = new DropDownManager();
            model.ListOfCities = dropDownManager.CityDropDown();
            return model;
        }

        public OfficeViewModel EditDefaultCityList(int id)
        {
            OfficeViewModel model = new OfficeViewModel();
            DropDownManager dropDownManager = new DropDownManager();
            model.ListOfCities = dropDownManager.CityDropDown();
            return model;
        }
    }
}