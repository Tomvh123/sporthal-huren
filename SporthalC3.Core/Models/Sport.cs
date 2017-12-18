using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SporthalC3.Models
{
    public class Sport
    { 
        public int SportID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<SportsHallSports> SportsHallSports { get; set; }
    }
}
