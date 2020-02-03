using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EpicOS.Models.Entities
{
    public class Device
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Device name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "MAC Address is required.")]
        public string MAC { get; set; }
        [Required(ErrorMessage = "IP Address is required.")]
        public string IPaddress { get; set; }
        [Required]
        public int Type { get; set; }

        public enum Types
        {
            Sensor = 1,
            Hub = 2,
            Laptop = 3,
            Desktop = 4,
            Phone = 5,
            Tablet = 6
        }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
