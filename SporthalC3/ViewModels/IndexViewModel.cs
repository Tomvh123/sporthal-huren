using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SporthalC3.Models;


namespace SporthalC3.ViewModels
{
    public class IndexViewModel
    {
        public List<Sport> sportList { get; set; }
        public List<SportsBuilding> sportBuildingList { get; set; }
    }
}
