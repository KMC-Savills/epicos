using EpicOS.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpicOS.Models.Results;
using EpicOS.Models.Entities;
using static EpicOS.Managers.DeviceManager;

namespace EpicOS.Managers
{
    public class DropDownManager : BaseManager
    {

        private LocationRepository locationRepository;
        private OfficeManager officeManager;
        private LocationManager locationManager;

        public DropDownManager()
        {
            this.locationRepository = new LocationRepository();
            this.officeManager = new OfficeManager();
            this.locationManager = new LocationManager();
        }
        public List<SelectListItem> OfficeDropDown()
        {
            List<SelectListItem> result = new List<SelectListItem>();
            List<Office> offices = officeManager.OfficeGetAll();
            foreach (Office office in offices)
            {
                //SelectListItem item = new SelectListItem();
                //item.Value = office.ID;
                //item.Text = office.Name;
                //result.Add(item);
                result.Add(new SelectListItem() { Value = office.ID.ToString(), Text = office.Name });
            }
            return result;
        }

        public List<SelectListItem> CityDropDown()
        {
            List<SelectListItem> result = new List<SelectListItem>();
            List<City> cities = locationManager.GetCities();
            foreach (City city in cities)
            {
                result.Add(new SelectListItem() { Value = city.CityID.ToString(), Text = city.CityName });
            }
            return result;
        }

        public List<SelectListItem> FloorDropdown()
        {
            List<SelectListItem> result = new List<SelectListItem>();
            List<Floor> floors = officeManager.FloorGetAll();
            foreach (Floor floor in floors)
            {
                SelectListItem item = new SelectListItem();
                item.Value = floor.ID.ToString();
                item.Text = floor.Name;
                result.Add(item);
            }
            return result;
        }
        public List<SelectListItem> DeviceTypeDropdown()
        {
            List<SelectListItem> result = new List<SelectListItem>();
            SelectListItem item1 = new SelectListItem() { Value = "1", Text = "Sensor" };
            SelectListItem item2 = new SelectListItem() { Value = "2", Text = "Hub" };
            result.Add(item1);
            result.Add(item2);
            return result;
        }

    }
}