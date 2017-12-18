using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SporthalC3;
using SporthalC3.Domain;
using SporthalC3.ViewModels;
using SporthalC3.Models;


namespace SporthalC3.Controllers
{
    public class FilterController : Controller
    {

        private ISportHalRepository repository;

        public FilterController(ISportHalRepository repo)
        {
            repository = repo;
        }

        public ViewResult FilterView(string sportname, string sportsBuildingName, int? Length, int? Width, int? NumberOfDressingSpace, int? NumberOfShowers, string canteenstring, bool? Canteen, string City, string OrderBy, int? price)
        { 
            if (canteenstring == "on")
                Canteen = true;
            
            FilterViewModel model = new FilterViewModel();
           
            model.SportsHalls = repository.SportsHall
                .Where(p => sportname == null || sportname == "null" || p.SportsHallSports.Any(x => x.Sport.Name == sportname))
                .Where(p => Length == null || p.Length >= Length)
                .Where(p => sportsBuildingName == null || p.SportsBuilding.Name.ToUpper().Contains(sportsBuildingName.ToUpper()))
                .Where(p => Width == null || p.Width >= Width)
                .Where(p => Canteen == null || p.SportsBuilding.Canteen == Canteen)
                .Where(p => price == 0 || price == null || p.Price <= price)
                .Where(p => NumberOfShowers == null || p.NumberOfShowers >= NumberOfShowers)
                .Where(p => City == null || City == "null" || p.SportsBuilding.City == City)
                .Where(p => NumberOfDressingSpace == null || p.NumberOfDressingSpace >= NumberOfDressingSpace)
                .ToList();

            switch (OrderBy)
            {
                case "hl":
                    model.SportsHalls = model.SportsHalls.OrderBy(x => x.Price).Reverse().ToList();
                    break;

                case "lh":
                    model.SportsHalls = model.SportsHalls.OrderBy(x => x.Price).ToList();
                    break;

                case "za":
                    model.SportsHalls = model.SportsHalls.OrderBy(x => x.SportsBuilding.Name).Reverse().ToList();
                    break;

                case "olh":
                    model.SportsHalls = model.SportsHalls.OrderBy(x => x.Length * x.Width).ToList();
                    break;

                case "ohl":
                    model.SportsHalls = model.SportsHalls.OrderBy(x => x.Length * x.Width).Reverse().ToList();
                    break;

                default:
                    model.SportsHalls = model.SportsHalls.OrderBy(x => x.SportsBuilding.Name).ToList();
                    break;
            }

            model.Sports = repository.Sport.ToList();
            model.SportBuildings = repository.SportsBuilding.ToList();

            if (City != null)
                model.SelectedCity = City;

            if (sportname != null)
                model.SelectedSport = sportname;

            if (Length != null)
                model.Length = Length.GetValueOrDefault();

            if (Width != null)
                model.Width = Width.GetValueOrDefault();

            if (NumberOfDressingSpace != null)
                model.NumberOfDressingSpace = NumberOfDressingSpace.GetValueOrDefault();

            if (NumberOfShowers != null)
                model.NumberOfShowers = NumberOfShowers.GetValueOrDefault();

            if (Canteen != null)
                model.Canteen = Canteen.GetValueOrDefault();

            if (OrderBy != null)
                model.OrderBy = OrderBy;

            if (price != null)
                model.Price = price.GetValueOrDefault();

            if (sportsBuildingName != null)
                model.SportsBuildingName = sportsBuildingName;

            return View("SportsHallListFilter", model);

        }
    }
}
   