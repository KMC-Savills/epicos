using EpicOS.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpicOS.Models.ViewModel
{
    public class BookViewModel : Book
    {
        public List<SelectListItem> ListOfOffices { get; set; }
        public List<SelectListItem> ListOfFloors { get; set; }
        public List<SelectListItem> ListOfWorkpoint { get; set; }
        public List<SelectListItem> ListOfUsers { get; set; }
    }
}
