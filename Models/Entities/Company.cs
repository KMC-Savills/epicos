using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpicOS.Models.Entities
{
    public class Company
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
