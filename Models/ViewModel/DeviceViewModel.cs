using EpicOS.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EpicOS.Models.ViewModel
{
    public class DeviceViewModel : Device
    {
        [Required]
        public int OfficeID { get; set; }
        [Required]
        public int FloorID { get; set; }
        [Required]
        public int RoomID { get; set; }
        [Required]
        public string OfficeName { get; set; }

        public double CoordinateX { get; set; }
        public double CoordinateY { get; set; }
        public double CoordinateZ { get; set; }

        public string Floor { get; set; }
        public List<SelectListItem> ListOfOffices { get; set; }
        public List<SelectListItem> ListOfFloors { get; set; }
        public List<SelectListItem> ListOfDeviceTypes { get; set; }
        public List<Log> ListOfLogs { get; set; }
    }
}
