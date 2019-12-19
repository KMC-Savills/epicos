using EpicOS.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpicOS.Models.ViewModel
{
    public class DeviceViewModel : Device
    {
        public int OfficeID { get; set; }
        public int FloorID { get; set; }
        public int RoomID { get; set; }
        public string OfficeName { get; set; }
        public string Floor { get; set; }
        public List<SelectListItem> ListOfOffices { get; set; }
        public List<SelectListItem> ListOfFloors { get; set; }
        public List<SelectListItem> ListOfDeviceTypes { get; set; }
    }
   


}
