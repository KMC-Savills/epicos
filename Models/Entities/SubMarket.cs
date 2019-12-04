using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpicOS.Models.Entities
{
    public class SubMarket
    {
        public int SubMarketID { get; set; }
        public string SubMarketName { get; set; }
        public int CityID { get; set; }
        public string Country { get; set; }
    }
}
