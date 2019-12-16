using EpicOS.Helpers;
using EpicOS.Models.Entities;
using EpicOS.Models.ViewModel;
using EpicOS.Repository;
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
                officeDetailsViewModels.Add(officeItems);
            }
            return officeDetailsViewModels;
        }

        public List<Floor> FloorGetAll()
        {
            List<Floor> floor = cacheNinja.cache["Floor_GetAll"] as List<Floor>;
            if (floor == null)
            {
                floor = officeRepo.FloorGetAll();
                cacheNinja.cache.Set("Office_GetAll", floor, cacheNinja.cacheExpiry);
            }
            return floor;
        }

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

        public Result OfficeInsert(Office office)
        {
            Result result = officeRepo.OfficeInsert(office);
            return result;
        }

        public Result OfficeUpdate(Office parameter)
        {
            return officeRepo.OfficeUpdate(parameter);
        }

        public Office OfficeGetByID(int id)
        {
            return OfficeGetAll().FirstOrDefault(e => e.ID.Equals(id));
        }

        public Floor FloorGetByID(int id)
        {
            return FloorGetAll().FirstOrDefault(e => e.ID.Equals(id));
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

        public Result FloorInsert(Floor floor)
        {
            Result result = officeRepo.FloorInsert(floor);
            return result;
        }

        public Result FloorUpdate(Floor floor)
        {
            Result result = officeRepo.FloorUpdate(floor);
            return result;
        }

        public Result Delete(int Id)
        {
            Office item = officeRepo.OfficeGetByID(Id);
            item.IsDeleted = true;
            Result result = officeRepo.OfficeUpdate(item);
            if (result.IsSuccess) 
            {
                cacheNinja.ClearCache("Office_GetAll");
            }

            return result;
        }
    }
}
