using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SporthalC3.Models
{
    public class SportsBuildingAdministrator
    {

        //public SportsBuildingAdministrator()
        //{
        //    SportBuildingList = new HashSet<SportsBuilding>();
        //}

       public int SportsBuildingAdministratorID { get; set;}

       [Required(ErrorMessage = "Please enter a firstname")]
       public string FirstName { get; set; }
        
       [Required(ErrorMessage = "Please enter a lastname")]
       public string LastName { get; set; }

       public virtual ICollection<SportsBuilding> SportBuildingList { get; set;}
    }
}
