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
    public class DeviceController : Controller
    {
        public IActionResult Index()
        {
            DeviceManager deviceManager = new DeviceManager();
            return View(deviceManager.DeviceGetAll());
        }
        //public void ReadyContextForView(int id = 0)
        //{
        //    DropDownManager dropDownManager = new DropDownManager();
        //    DeviceViewModel deviceViewModel = new DeviceViewModel();
        //    deviceViewModel.ListOfOffices = dropDownManager.OfficeDropDown();
        //    ViewBag.Context = deviceViewModel;
        //}

        public DeviceViewModel DefaultValueListing()
        {
            DeviceViewModel deviceViewModel = new DeviceViewModel();
            DropDownManager dropDownManager = new DropDownManager();
            deviceViewModel.ListOfOffices = dropDownManager.OfficeDropDown();
            return deviceViewModel;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(DefaultValueListing());
        }

        [HttpPost]
        public IActionResult Create(Workpoint workpoint)
        {
            DeviceManager deviceManager = new DeviceManager();
            deviceManager.WorkpointInsert(workpoint);

            CacheNinja ninja = new CacheNinja();
            ninja.ClearCache("Workpoint_GetAll");
            return RedirectToAction("Index");
        }

    }
}