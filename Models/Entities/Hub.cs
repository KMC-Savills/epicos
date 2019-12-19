using EpicOS.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpicOS.Models.Entities
{
    public class Hub : Device
    {

        public int DeviceType { get; set; }
        public int OfficeID { get; set; }
        public int FloorID { get; set; }
        public int RoomID { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
