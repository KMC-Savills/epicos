using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpicOS.Models.Entities
{
    public class Device
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string MAC { get; set; }
        public string IPAddress { get; set; }
    }
}
