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
            ViewBag.Context = context;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(DefaultValueListing());
        }

        [HttpPost]
        public IActionResult Add(Workpoint workpoints, Hub hubs)
        {
            if (workpoints.Type == 1)
            {
                deviceManager.WorkpointInsert(workpoints);
            }
            else
            if (hubs.Type == 2)
            {
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
        public IActionResult Edit(Workpoint workpoint, Hub hub, int type)
        {
            switch (type)
            {
                case 1:
                    deviceManager.WorkpointUpdate(workpoint);
                    cacheNinja.ClearCache("Workpoint_GetAll");
                    break;
                case 2:
                    deviceManager.HubUpdate(hub);
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

