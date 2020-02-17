using EpicOS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpicOS.Models.ViewModel
{
    public class FloorViewModel : Floor
    {
        public List<Workpoint> ListOfWorkpoints { get; set; }
        public List<Hub> ListOfHubs { get; set; }
    }
}
