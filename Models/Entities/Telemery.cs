using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpicOS.Models.Entities
{
    public class Telemery
    {
        public int ID { get; set; }
        public string MAC { get; set; }
        public string IPAddress { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Battery { get; set; }
        public int HubID { get; set; }
        public int WorkpointID { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
