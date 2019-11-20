using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpicOS.Models.Parameters
{
    public class TelemeryFilter
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int OfficeID { get; set; }
        public int FloorID { get; set; }
    }
}
