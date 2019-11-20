﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpicOS.Models.Entities
{
    public class Office
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int CityID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Filename { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

    }
}
