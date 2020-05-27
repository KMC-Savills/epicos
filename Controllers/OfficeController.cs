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
        private OfficeManager officeManager = new OfficeManager();
        private DropDownManager ddManager = new DropDownManager();

        IHostingEnvironment hosting;
        private string officeFilePath = "uploads\\img\\office";

        public OfficeController(IHostingEnvironment host)
        {
            hosting = host;
        }

        public IActionResult Index(Office office)
        {
            var model = officeManager.OfficeExtendedGetAll();
            if (model == null)
            {
                ViewBag.Message = "Record is empty!";
                return View(model);
            }
            return View(model);
        }

        public void ReadyContextForView(int id = 0)
        {
            OfficeViewModel context = new OfficeViewModel();
            context.ListOfCities = ddManager.CityDropDown();
            ViewBag.Context = context;
        }

        public IActionResult OfficeList()
        {
            return View(officeManager.OfficeGetAll());
        }

        [HttpGet]
        public ActionResult GetOfficeId(string id)
        {
            ViewBag.CaseId = id;
            return View();
        }

        public ActionResult Details(int id)
        {
            return View(officeManager.OfficeGetByID(id));
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
                var files = HttpContext.Request.Form.Files;

                Result result = officeManager.OfficeInsert(office);
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
                                officeManager.OfficeUpdate(office);
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
            var model = officeManager.OfficeGetByID(id);
            ReadyContextForView(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Office office)
        {
            var files = HttpContext.Request.Form.Files;
            Result result = officeManager.OfficeUpdate(office);
            if (result.IsSuccess)
            {
                foreach (var Image in files)
                {
                    var file = Image;
                    var uploads = Path.Combine(hosting.WebRootPath, officeFilePath + "\\" + office.ID);
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
                            officeManager.OfficeUpdate(office);
                        }
                    }
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            officeManager.OfficeDelete(Id);
            return RedirectToAction("Index");
        }
        public OfficeViewModel DefaultValueListing()
        {
            var defaultDate = DateTime.UtcNow;
            OfficeViewModel officeViewModel = new OfficeViewModel();
            officeViewModel.Latitude = 14.5477349;
            officeViewModel.Longitude = 121.04621500000007;
            officeViewModel.ListOfCities = ddManager.CityDropDown();
            return officeViewModel;
        }

        public OfficeViewModel EditDefaultCityList(int id)
        {
            OfficeViewModel officeViewModel = new OfficeViewModel();
            officeViewModel.ListOfCities = ddManager.CityDropDown();
            return officeViewModel;
        }
    }
}