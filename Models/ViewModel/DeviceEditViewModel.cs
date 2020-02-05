using EpicOS.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EpicOS.Models.ViewModel
{
    public class DeviceEditViewModel : Device
    {
        public string TypeName { get; set; }
        [Required]
        public List<SelectListItem> ListOfOffices { get; set; }
        //[Required]
        //public List<SelectListItem> ListOfFloors { get; set; }
        //[Required]
        //public List<SelectListItem> ListOfDeviceTypes { get; set; }
    }
   
}
