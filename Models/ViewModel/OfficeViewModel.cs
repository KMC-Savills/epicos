using EpicOS.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpicOS.Models.ViewModel
{
    public class OfficeViewModel : Office
    {
        public List<SelectListItem> ListOfCities { get; set;}
    }
}
