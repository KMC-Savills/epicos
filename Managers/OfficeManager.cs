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
        private OfficeRepository officeRepository;

        public OfficeManager()
        {
            this.officeRepository = new OfficeRepository();
        }

        public List<Office> OfficeGetAll()
        {
            List<Office> office = cacheNinja.cache["Office_GetAll"] as List<Office>;
            if (office == null)
            {
                office = officeRepository.OfficeGetAll();
                cacheNinja.cache.Set("Office_GetAll", office, cacheNinja.cacheExpiry);
            }
            return office;
        }

        public List<Floor> FloorGetAll()
        {
            List<Floor> floor = cacheNinja.cache["Floor_GetAll"] as List<Floor>;
            if (floor == null)
            {
                floor = officeRepository.FloorGetAll();
                cacheNinja.cache.Set("Office_GetAll", floor, cacheNinja.cacheExpiry);
            }
            return floor;
        }

        public List<Company> CompanyGetAll()
        {
            List<Company> company = cacheNinja.cache["Company_GetAll"] as List<Company>;
            if (company == null)
            {
                company = officeRepository.CompanyGetAll();
                cacheNinja.cache.Set("Office_GetAll", company, cacheNinja.cacheExpiry);
            }
            return company;
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
            Result result = officeRepository.CompanyInsert(company);
            return result;
        }

        public Result CompanyUpdate(Company company)
        {
            Result result = officeRepository.CompanyUpdate(company);
            return result;
        }

        public Result FloorInsert(Floor floor)
        {
            Result result = officeRepository.FloorInsert(floor);
            return result;
        }

        public Result FloorUpdate(Floor floor)
        {
            Result result = officeRepository.FloorUpdate(floor);
            return result;
        }
    }
}
