using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpicOS.Models.Entities
{
    public class Hub
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int DeviceType { get; set; }
        public string MAC { get; set; }
        public string IPAddress { get; set; }
        public int OfficeID { get; set; }
        public int FloorID { get; set; }
        public int RoomID { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
