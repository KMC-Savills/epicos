using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EpicOS.Managers;
using EpicOS.Models.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EpicOS.Controllers
{
    public class FloorController : Controller
    {
        private OfficeManager officeManager = new OfficeManager();
        private DeviceManager deviceManager = new DeviceManager();

        IHostingEnvironment hosting;
        private string officeFilePath = "uploads\\img\\office";

        public FloorController(IHostingEnvironment host)
        {
            hosting = host;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            return View(officeManager.DeviceGetByFloorID(id));
        }
        [HttpGet]
        public IActionResult Assign(int id)
        {
            return View(officeManager.DeviceGetByFloorID(id));
        }
        [HttpPost]
        public IActionResult Assign(Workpoint workpoint)
        {
            deviceManager.WorkpointUpdate(workpoint);
            return Redirect("/Office/Details/" + workpoint.OfficeID);
        }
        [HttpGet]
        public IActionResult Monitor()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(Floor floor)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                Result result = officeManager.FloorInsert(floor);
                if (result.IsSuccess)
                {
                    foreach (var Image in files)
                    {
                        var file = Image;
                        var uploads = Path.Combine(hosting.WebRootPath, officeFilePath + "\\" + floor.OfficeID + "\\floor\\" + result.ID);
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
                                floor.ID = result.ID;
                                floor.Filename = fileName;
                                officeManager.FloorUpdate(floor);
                            }
                        }
                    }
                    return Redirect("/Office/Details/" + floor.OfficeID);
                }
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(officeManager.FloorGetByID(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Floor floor)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                Result result = officeManager.FloorUpdate(floor);
                if (result.IsSuccess)
                {
                    foreach (var image in files)
                    {
                        var newFile = image;
                        var uploads = Path.Combine(hosting.WebRootPath, officeFilePath + "\\" + floor.OfficeID + "\\floor\\" + floor.ID);
                        if (!Directory.Exists(uploads))
                        {
                            Directory.CreateDirectory(uploads);
                        }
                        if (newFile.Length > 0)
                        {
                            var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(newFile.FileName);
                            using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                            {
                                await newFile.CopyToAsync(fileStream);
                                floor.Filename = fileName;
                                officeManager.FloorUpdate(floor);
                            }
                        }
                    }

                }
            }
            else
            {
                ViewBag.Error = "Error, something is not right";
            }

            return Redirect("/office/details/" + floor.OfficeID);
        }
    }
}
