using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpicOS.Models.Entities
{
    public class City
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
        public string Province { get; set; }
        public int Region { get; set; }
        public string Country { get; set; }
        public string Coordinates { get; set; }
        public object ID { get; internal set; }
    }
}
