using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SporthalC3.Models
{
    public class Reserve
    {
        public int ReserveID { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime Datum { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String Email { get; set; }

        public String Context { get; set; }

        public int PhoneNumber { get; set; }

        public virtual SportsHall SportsHall { get; set; }

        public Sport Sport { get; set; }
    }
}
