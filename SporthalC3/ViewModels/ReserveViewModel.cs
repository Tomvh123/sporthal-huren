using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SporthalC3.Models;

namespace SporthalC3.ViewModels
{
    public class ReserveViewModel
    {
        
        public SportsHall SportsHall { get; set; }

        public int SporthallID { get; set; }

        public int TimeL { get; set; }

        public int Tijdsduur { get; set; }

        public bool futureReserves { get; set; }

        public string seachEmail { get; set; }

        public string OrderBy { get; set; }

        public Reserve Reserve { get; set; }

        public List<Reserve> ReserveList { get; set;}

        public DateTime Date { get; set; }

        public List<int> TimeList { get; set; }

        public List<int> TimeSpanList { get; set; }
    
        public bool Searched { get; set; }
    }
}
