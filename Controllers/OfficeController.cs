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
using Microsoft.AspNetCore.Hosting;

namespace EpicOS.Controllers
{
    public class OfficeController : Controller
    {
        IHostingEnvironment hosting;
        private string officeFilePath = "uploads\\img\\office";

        public OfficeController(IHostingEnvironment host)
        {
            hosting = host;
        }

        public IActionResult Index(Office office)
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
            OfficeManager manager = new OfficeManager();
            return View(manager.OfficeGetByID(id));

        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(DefaultValueListing());
        }

        [HttpPost]
        public async Task<ActionResult> Add(Office office)
        {

            if (ModelState.IsValid)
            {
                OfficeManager manager = new OfficeManager();
                var files = HttpContext.Request.Form.Files;

                Result result = manager.OfficeInsert(office);
                if (result.IsSuccess)
                {
                    foreach (var Image in files)
                    {
                        var file = Image;
                        var uploads = Path.Combine(hosting.WebRootPath, officeFilePath + "\\" + result.ID);
                        if (!Directory.Exists(uploads))
                        {
                            Directory.CreateDirectory(uploads);
                        }
                        if (file.Length > 0)
                        {
                            var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                            using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                                office.Filename = fileName;
                                office.ID = result.ID;
                                manager.OfficeUpdate(office);
                            }
                        }
                    }
                    return RedirectToAction("Index");
                }
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }
            return View();
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