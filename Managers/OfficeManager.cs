using EpicOS.Helpers;
using EpicOS.Models.Entities;
using EpicOS.Models.ViewModel;
using EpicOS.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpicOS.Managers
{
    public class OfficeManager : BaseManager
    {
        private OfficeRepository officeRepo;
        public OfficeManager()
        {
            this.officeRepo = new OfficeRepository();
        }

        #region Office

        public List<Office> OfficeGetAll()
        {
            List<Office> offices = cacheNinja.cache["Office_GetAll"] as List<Office>;
            if (offices == null)
            {
                offices = officeRepo.OfficeGetAll();
                cacheNinja.cache.Set("Office_GetAll", offices, cacheNinja.cacheExpiry);
            }
            return offices;
        }

        public List<OfficeDetailsViewModel> OfficeExtendedGetAll()
        {
            List<OfficeDetailsViewModel> officeDetailsViewModels = new List<OfficeDetailsViewModel>();
            List<Office> offices = OfficeGetAll();
            LocationManager locationManager = new LocationManager();
            List<City> cities = locationManager.GetCities();
            foreach (Office office in offices)
            {
                OfficeDetailsViewModel officeItems = new OfficeDetailsViewModel();
                officeItems.ID = office.ID;
                officeItems.Name = office.Name;
                officeItems.Address = office.Address;
                officeItems.CityID = office.CityID;
                officeItems.Latitude = office.Latitude;
                officeItems.Longitude = office.Longitude;
                officeItems.Filename = office.Filename;
                officeItems.IsActive = office.IsActive;
                officeItems.IsDeleted = office.IsDeleted;
                officeItems.CityName = cities.First(item => item.CityID.Equals(office.CityID)).CityName;
                officeItems.Floors = FloorGetAll().Where(f => f.OfficeID.Equals(office.ID)).ToList();
                officeDetailsViewModels.Add(officeItems);
            }
            return officeDetailsViewModels;
        }

        public Result OfficeInsert(Office office)
        {
            Result result = officeRepo.OfficeInsert(office);
            if (result.IsSuccess)
            {
                cacheNinja.AddItemToCache("Office_GetAll", office);
            }
            return result;
        }

        public Result OfficeUpdate(Office parameter)
        {
            Result result = officeRepo.OfficeUpdate(parameter);
            cacheNinja.ClearCache("Office_GetAll");
            return result;
        }

        public Result OfficeDelete(int id)
        {
            Office item = officeRepo.OfficeGetByID(id);
            item.IsDeleted = true;
            Result result = officeRepo.OfficeUpdate(item);
            if (result.IsSuccess)
            {
                cacheNinja.ClearCache("Office_GetAll");
            }
            return result;
        }

        public OfficeDetailsViewModel OfficeGetByID(int id)
        {
            return OfficeExtendedGetAll().FirstOrDefault(e => e.ID.Equals(id));
        }

        #endregion

        #region Floor

        public List<Floor> FloorGetAll()
        {
            List<Floor> floor = cacheNinja.cache["Floor_GetAll"] as List<Floor>;
            if (floor == null)
            {
                floor = officeRepo.FloorGetAll();
                cacheNinja.cache.Set("Floor_GetAll", floor, cacheNinja.cacheExpiry);
            }
            return floor;
        }
        public FloorViewModel DeviceGetByFloorID(int id)
        {
            return GetDevicesByFloorID().FirstOrDefault(e => e.ID.Equals(id));
        }
        public List<FloorViewModel> GetDevicesByFloorID()
        {
            DeviceManager deviceManager = new DeviceManager();
            List<FloorViewModel> floorViewModels = new List<FloorViewModel>();
            List<Workpoint> workpoints = deviceManager.WorkpointGetAll();
            List<Hub> hubs = deviceManager.HubGetAll();
            List<Floor> floors = FloorGetAll();
            foreach (Floor floor in floors)
            {
                FloorViewModel floorItems = new FloorViewModel();
                floorItems.ID = floor.ID;
                floorItems.Name = floor.Name;
                floorItems.Filename = floor.Filename;
                floorItems.Type = floor.Type;
                floorItems.OfficeID = floor.OfficeID;
                floorItems.IsActive = floor.IsActive;
                floorItems.IsDeleted = floor.IsDeleted;
                floorItems.ListOfWorkpoints = deviceManager.WorkpointGetAll().Where(w => w.FloorID.Equals(floor.ID)).ToList();
                floorItems.ListOfHubs = deviceManager.HubGetAll().Where(h => h.FloorID.Equals(floor.ID)).ToList();
                floorViewModels.Add(floorItems);
            }
            return floorViewModels;
        }
        public Floor FloorGetByID(int id)
        {
            return FloorGetAll().FirstOrDefault(e => e.ID.Equals(id));
        }

        public Result FloorInsert(Floor floor)
        {
            Result result = officeRepo.FloorInsert(floor);
            cacheNinja.ClearCache("Floor_GetAll");
            return result;
        }

        public Result FloorUpdate(Floor floor)
        {
            Result result = officeRepo.FloorUpdate(floor);
            cacheNinja.ClearCache("Floor_GetAll");
            return result;
        }

        public Result FloorDelete(Floor floor)
        {
            Result result = officeRepo.FloorUpdate(floor);
            return result;
        }
        public List<Floor> FloorGetByOfficeID(int id)
        {
            return FloorGetAll().Where(f => f.OfficeID.Equals(id)).ToList();
        }
        #endregion

        #region Company

        public List<Company> CompanyGetAll()
        {
            List<Company> company = cacheNinja.cache["Company_GetAll"] as List<Company>;
            if (company == null)
            {
                company = officeRepo.CompanyGetAll();
                cacheNinja.cache.Set("Office_GetAll", company, cacheNinja.cacheExpiry);
            }
            return company;
        }

        public Company CompanyGetByID(int id)
        {
            return CompanyGetAll().FirstOrDefault(e => e.ID.Equals(id));
        }

        public Result CompanyInsert(Company company)
        {
            Result result = officeRepo.CompanyInsert(company);
            return result;
        }

        public Result CompanyUpdate(Company company)
        {
            Result result = officeRepo.CompanyUpdate(company);
            return result;
        }

        #endregion

    }
}
