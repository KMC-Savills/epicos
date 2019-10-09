using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpicOS.Models.Entities
{
    public class Book
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int WorkpointID { get; set; }
        public int FloorID { get; set; }
        public int OfficeID { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
