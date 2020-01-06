using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpicOS.Models.Entities
{
    public class Log
    {
        public int ID { get; set; }
        public DateTime DateCreated { get; set; }
        public string MAC { get; set; }
        public string IPaddress { get; set; }
        public string Message { get; set; }
        public bool IsDeleted { get; set; }
    }
}
