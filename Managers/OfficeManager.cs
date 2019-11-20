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
        public List<Office> GetAll()
        {
            OfficeRepository repository = new OfficeRepository();
            return repository.GetAll();
        }
    }
}
