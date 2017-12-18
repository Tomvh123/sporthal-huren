using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SporthalC3.Models
{
    
    public class SportsHall
    {
        //public SportsHall()
        //{
        //    Reserve = new HashSet<Reserve>();
        //    SportsHallSports = new HashSet<SportsHallSports>();

        //}

        public int SportsHallID { get; set; }

        public double Price { get; set; }

        public double Length { get; set; }

        public double Width { get; set; }

        public int NumberOfShowers { get; set; }

        public int NumberOfDressingSpace { get; set; }

        public DateTime OpenTime { get; set; }

        public DateTime CloseTime { get; set; }

        public virtual SportsBuilding SportsBuilding { get; set; }
                
        public virtual ICollection<SportsHallSports> SportsHallSports { get; set; }

        public virtual ICollection<Reserve> Reserve { get; set; }

        





    }
}
