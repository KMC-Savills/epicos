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
        public string IPaddress { get; set; }
        public int Type { get; set; }

        public enum Types
        {
            Sensor = 1,
            Hub = 2,
            Laptop = 3,
            Desktop = 4,
            Phone = 5,
            Tablet = 6
        }
    }
}
