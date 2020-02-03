using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpicOS.Models.Entities
{
    public class Workpoint : Device
    {
        public double CoordinateX { get; set; }
        public double CoordinateY { get; set; }
        public double CoordinateZ { get; set; }
        public int OfficeID { get; set; }
        public int FloorID { get; set; }    
        public int RoomID { get; set; }
        public int HubID { get; set; }
    }
}
