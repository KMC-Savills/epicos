using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpicOS.Models.Results
{
    public class GenericObject
    {
        public GenericObject()
        {

        }

        public GenericObject(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }

        public int ID { get; set; }
        public string Name { get; set; }
    }
}
