using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace EpicOS.Models.Entities
{
    public class Office
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "This field is required, please input an office name!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required, please input an address!")]
        public string Address { get; set; }
        [Required]
        public int CityID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Filename { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

    }
}
