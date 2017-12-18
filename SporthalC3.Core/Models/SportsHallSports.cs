using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SporthalC3.Models
{
    public class SportsHallSports
    {
        public int SportsHallId { get; set; }

        public virtual SportsHall SportsHall { get; set; }

        public int SportsId { get; set; }

        public virtual Sport Sport { get; set; }
    }
}
