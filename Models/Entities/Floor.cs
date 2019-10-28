using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpicOS.Models.Entities
{
    public class Floor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Filename { get; set; }
        public int Type { get; set; }
        public int OfficeID { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
