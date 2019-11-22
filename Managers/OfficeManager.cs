using EpicOS.Helpers;
using EpicOS.Models.Entities;
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
