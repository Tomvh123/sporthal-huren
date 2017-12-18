using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SporthalC3.Models;



namespace SporthalC3.ViewModels
{
    public class FilterViewModel {
    
        public List<SportsHall> SportsHalls { get; set; }

        public List<SportsBuilding> SportBuildings { get; set; }

        public List<Sport> Sports { get; set; }

        public string SportsBuildingName { get; set; }

        public string SelectedCity { get; set; }

        public string SelectedSport { get; set; }

        public int Length { get; set; }

        public int Width { get; set; }

        public double Price { get; set; }

        public int NumberOfDressingSpace { get; set; }

        public int NumberOfShowers { get; set; }

        public bool Canteen { get; set; }

        public string OrderBy { get; set; }

    }
}
