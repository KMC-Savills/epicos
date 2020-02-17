using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EpicOS.Managers;
using EpicOS.Models.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace EpicOS.Controllers
{
    public class FloorController : Controller
    {
        OfficeManager manager = new OfficeManager();

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

        public IActionResult Assign()
        {
            return View();
        }

        public IActionResult Monitor()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            OfficeManager officeManager = new OfficeManager();
            return View(officeManager.DeviceGetByFloorID(id));
        }
        [HttpPost]
        public async Task<ActionResult> Add(Floor floor)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                Result result = manager.FloorInsert(floor);
                if (result.IsSuccess)
                {
                    foreach (var Image in files)
                    {
                        var file = Image;
                        var uploads = Path.Combine(hosting.WebRootPath, officeFilePath + "\\" + floor.OfficeID + "\\floor\\" + +result.ID);
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
                                manager.FloorUpdate(floor);
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
    }
}

//public List<OfficeDetailsViewModel> OfficeExtendedGetAll()
//{
//    List<OfficeDetailsViewModel> officeDetailsViewModels = new List<OfficeDetailsViewModel>();
//    List<Office> offices = OfficeGetAll();
//    LocationManager locationManager = new LocationManager();
//    List<City> cities = locationManager.GetCities();
//    foreach (Office office in offices)
//    {
//        OfficeDetailsViewModel officeItems = new OfficeDetailsViewModel();
//        officeItems.ID = office.ID;
//        officeItems.Name = office.Name;
//        officeItems.Address = office.Address;
//        officeItems.CityID = office.CityID;
//        officeItems.Latitude = office.Latitude;
//        officeItems.Longitude = office.Longitude;
//        officeItems.Filename = office.Filename;
//        officeItems.IsActive = office.IsActive;
//        officeItems.IsDeleted = office.IsDeleted;
//        officeItems.CityName = cities.First(item => item.CityID.Equals(office.CityID)).CityName;
//        officeItems.Floors = FloorGetAll().Where(f => f.OfficeID.Equals(office.ID)).ToList();
//        officeDetailsViewModels.Add(officeItems);
//    }
//    return officeDetailsViewModels;
//}