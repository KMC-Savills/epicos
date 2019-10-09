using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpicOS.Models.Entities
{
    public class Workpoint
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string MAC { get; set; }
        public string IPAddress { get; set; }
        public float CoordinateX { get; set; }
        public float CoordinateY { get; set; }
        public float CoordinateZ { get; set; }
        public int OfficeID { get; set; }
        public int FloorID { get; set; }
        public int RoomID { get; set; }
        public int HubID { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
