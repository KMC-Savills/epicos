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
using Microsoft.AspNetCore.Mvc.Rendering;
namespace EpicOS.Controllers
{
    public class DeviceController : Controller
    {
        public IActionResult Index()
        {
            DeviceManager deviceManager = new DeviceManager();
            return View(deviceManager.DeviceGetAll());
        }

        public DeviceViewModel DefaultValueListing()
        {
            DeviceViewModel deviceViewModel = new DeviceViewModel();
            DropDownManager dropDownManager = new DropDownManager();
            deviceViewModel.ListOfOffices = dropDownManager.OfficeDropDown();
            deviceViewModel.ListOfFloors = dropDownManager.FloorDropdown();
            deviceViewModel.ListOfDeviceTypes = dropDownManager.DeviceTypeDropdown();
            return deviceViewModel;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(DefaultValueListing());
        }

        [HttpPost]
        public IActionResult Add(DeviceViewModel deviceViewModel)
        {
            DeviceManager deviceManager = new DeviceManager();
            if (deviceViewModel.Type == 1)
            {
                Workpoint workpoint = new Workpoint();
                workpoint.Name = deviceViewModel.Name;
                workpoint.Type = deviceViewModel.Type;
                workpoint.MAC = deviceViewModel.MAC;
                workpoint.IPaddress = deviceViewModel.IPaddress;
                workpoint.OfficeID = deviceViewModel.OfficeID;
                workpoint.FloorID = deviceViewModel.FloorID;
                deviceManager.WorkpointInsert(workpoint);
            }
            else
            if (deviceViewModel.Type == 2)
            {
                Hub hubs = new Hub();
                hubs.ID = deviceViewModel.ID;
                hubs.Name = deviceViewModel.Name;
                hubs.Type = deviceViewModel.Type;
                hubs.MAC = deviceViewModel.MAC;
                hubs.IPaddress = deviceViewModel.IPaddress;
                hubs.OfficeID = deviceViewModel.OfficeID;
                hubs.FloorID = deviceViewModel.FloorID;
                deviceManager.HubInsert(hubs);
            }
            CacheNinja ninja = new CacheNinja();
            ninja.ClearCache("Workpoint_GetAll");
            ninja.ClearCache("Hub_GetAll");
            return RedirectToAction("Index");
        }
        
    }
}