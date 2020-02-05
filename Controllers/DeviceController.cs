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
        private DeviceManager deviceManager = new DeviceManager();
        private DeviceViewModel deviceViewModel = new DeviceViewModel();
        private DropDownManager dropDownManager = new DropDownManager();
        private CacheNinja cacheNinja = new CacheNinja();
        private DeviceEditViewModel devicedetailsViewModel = new DeviceEditViewModel();

        public IActionResult Index()
        {

            return View(deviceManager.DeviceGetAll());
        }

        public DeviceViewModel DefaultValueListing()
        {
            deviceViewModel.ListOfOffices = dropDownManager.OfficeDropDown();
            deviceViewModel.ListOfFloors = dropDownManager.FloorDropdown();
            deviceViewModel.ListOfDeviceTypes = dropDownManager.DeviceTypeDropdown();
            return deviceViewModel;
        }

        public void DropdownForEdit()
        {
            DeviceEditViewModel context = new DeviceEditViewModel();
            context.ListOfOffices = dropDownManager.OfficeDropDown();
            //context.ListOfFloors = dropDownManager.FloorDropdown();
            //context.ListOfDeviceTypes = dropDownManager.DeviceTypeDropdown();
            ViewBag.Context = context;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(DefaultValueListing());
        }

        [HttpPost]
        public IActionResult Add(DeviceViewModel deviceViewModel)
        {
            if (deviceViewModel.Type == 1)
            {
                Workpoint workpoint = new Workpoint();
                workpoint.Name = deviceViewModel.Name;
                workpoint.Type = deviceViewModel.Type;
                workpoint.MAC = deviceViewModel.MAC;
                workpoint.IPaddress = deviceViewModel.IPaddress;
                workpoint.OfficeID = deviceViewModel.OfficeID;
                workpoint.FloorID = deviceViewModel.FloorID;
                workpoint.IsActive = deviceViewModel.IsActive;
                workpoint.IsDeleted = deviceViewModel.IsDeleted;
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
                hubs.IsActive = deviceViewModel.IsActive;
                hubs.IsDeleted = deviceViewModel.IsDeleted;
                deviceManager.HubInsert(hubs);
            }
            cacheNinja.ClearCache("Workpoint_GetAll");
            cacheNinja.ClearCache("Hub_GetAll");
            return RedirectToAction("Index");
        }
       
        [HttpGet]
        public IActionResult Details(int id, int type)
        {
            return View(deviceManager.DeviceGetByID(id, type));
        }
        [HttpGet]
        public IActionResult Edit(int id, int type)
        {
            DropdownForEdit();
            return View(deviceManager.DeviceGetByID(id, type));
        }

        [HttpPost]
        public IActionResult Edit(DeviceViewModel deviceViewModel, int type)
        {
            switch (type)
            {
                case 1:
                    Workpoint workpoints = new Workpoint();
                    workpoints.ID = deviceViewModel.ID;
                    workpoints.Name = deviceViewModel.Name;
                    workpoints.Type = deviceViewModel.Type;
                    workpoints.MAC = deviceViewModel.MAC;
                    workpoints.IPaddress = deviceViewModel.IPaddress;
                    workpoints.OfficeID = deviceViewModel.OfficeID;
                    workpoints.FloorID = deviceViewModel.FloorID;
                    workpoints.IsActive = deviceViewModel.IsActive;
                    workpoints.IsDeleted = deviceViewModel.IsDeleted;
                    deviceManager.WorkpointUpdate(workpoints);
                    cacheNinja.ClearCache("Workpoint_GetAll");
                    break;
                case 2:
                    Hub hubs = new Hub();
                    hubs.ID = deviceViewModel.ID;
                    hubs.Name = deviceViewModel.Name;
                    hubs.Type = deviceViewModel.Type;
                    hubs.MAC = deviceViewModel.MAC;
                    hubs.IPaddress = deviceViewModel.IPaddress;
                    hubs.OfficeID = deviceViewModel.OfficeID;
                    hubs.FloorID = deviceViewModel.FloorID;
                    hubs.IsActive = deviceViewModel.IsActive;
                    hubs.IsDeleted = deviceViewModel.IsDeleted;
                    deviceManager.HubUpdate(hubs);
                    cacheNinja.ClearCache("Hub_GetAll");
                    break;
                default:
                    break;
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id, int type)
        {
            deviceManager.Delete(id, type);
            return RedirectToAction("Index");
        }
    }
}

