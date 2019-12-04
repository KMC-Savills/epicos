using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpicOS.Models.Entities
{
    public class Region
    {

        public int RegionID { get; set; }
        public string RegionName { get; set; }
        public string Coordinates { get; set; }
        public bool IsDeleted { get; set; }
    }
}
