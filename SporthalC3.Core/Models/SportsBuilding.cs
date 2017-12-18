using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SporthalC3.Models
{
    public class SportsBuilding
    {

        //public SportsBuilding()
        //{
        //    SportsHallList = new HashSet<SportsHall>();
        //}

        public int SportsBuildingID { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string PostalCode { get; set; }

        public int HouseNumber { get; set; }

        public bool Canteen { get; set; }

        public virtual SportsBuildingAdministrator SportsBuildingAdministrator {get; set;}

        public virtual ICollection<SportsHall> SportsHallList { get; set; }
    }
}
