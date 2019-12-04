﻿using EpicOS.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpicOS.Models.Results;
using EpicOS.Models.Entities;

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
        //public List<SelectListItem> CityList()
        //{
        //    List<SelectListItem> cities = cacheNinja.cache["usp_City_GetAll"] as List<SelectListItem>;
        //    if (cities == null)
        //    {
        //        cities = new List<SelectListItem>();
        //        foreach (GenericObject city in locationRepository.CityGetAll())
        //        {
        //            SelectListItem x = new SelectListItem();
        //            cities.Add(new SelectListItem() { Value = city.ID.ToString(), Text = city.Name });
        //        }
        //        cacheNinja.cache.Set("usp_City_GetAll", cities, cacheNinja.cacheExpiry);
        //    }
        //    return cities;
        //}
        public List<SelectListItem> OfficeDropDown()
        {
            List<SelectListItem> result = new List<SelectListItem>();
            List<Office> offices = officeManager.OfficeGetAll();
            foreach(Office office in offices)
            {
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
                result.Add(new SelectListItem() { Value = city.CityID.ToString(), Text = city.CityName});
            }
            return result;
        }
    }
}