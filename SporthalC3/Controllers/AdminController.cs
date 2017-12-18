using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SporthalC3.Domain;
using Microsoft.AspNetCore.Authorization;
using SporthalC3.Models;


namespace SporthalC3.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private ISportHalRepository repository;

        public AdminController(ISportHalRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index() => View();
        public ViewResult SportsBuildingAdministrator() => View(repository.SportsBuildingAdministrator);
        public ViewResult Sport() => View(repository.Sport);
        public ViewResult SportsHall() => View(repository.SportsHall);
        public ViewResult SportsBuilding() => View(repository.SportsBuilding);
        public ViewResult EditSportView(int sportID) =>
            View("SportEdit", repository.Sport.FirstOrDefault(p => p.SportID == sportID));

        public ViewResult EditSportBuildingAdministratorView(int sportBuildingAdministratorID) =>
            View("SportsBuildingAdministratorEdit", repository.SportsBuildingAdministrator.FirstOrDefault(p => p.SportsBuildingAdministratorID == sportBuildingAdministratorID));

        public ViewResult EditSportBuildingView(int sportBuildingID) =>
            View("SportsBuildingEdit", repository.SportsBuilding.FirstOrDefault(p => p.SportsBuildingID == sportBuildingID));

        public ViewResult EditSportHallView(int sportHallID) =>
            View("SportHallEdit", repository.SportsHall.FirstOrDefault(p => p.SportsHallID == sportHallID));


        [HttpPost]
        public IActionResult EditSportsBuildingAdministrator(SportsBuildingAdministrator sportsBuildingAdministrator)
        {
            if (ModelState.IsValid)
            {
                repository.SaveSportsBuildingAdministrator(sportsBuildingAdministrator);
                return RedirectToAction("SportsBuildingAdministrator");
            } else
            {
                // there is something wrong with the data values.
                return View(sportsBuildingAdministrator);
            }
        }

        public ViewResult CreateSportsBuildingAdministrator() => View("SportsBuildingAdministratorEdit", new SportsBuildingAdministrator());

        [HttpPost]
        public IActionResult DeleteSportsBuildingAdministrator(int SportsBuildingAdministratorID)
        {
            SportsBuildingAdministrator deletedSportsBuildingAdministrator = repository.DeleteSportsBuildingAdministrator(SportsBuildingAdministratorID);
            if (deletedSportsBuildingAdministrator != null)
            {
                //TempData["message"] = $"{deletedSportsBuildingAdministrator.FirstName} was deleted";
            }
            return RedirectToAction("SportsBuildingAdministrator");
        }

        [HttpPost]
        public IActionResult EditSport(Sport sport)
        {
            if (ModelState.IsValid)
            {
                repository.SaveSport(sport);
                return RedirectToAction("Sport");
            }
            else
            {
                // there is something wrong with the data values
                return View(sport);
            }
        }

        public ViewResult CreateSport() => View("SportEdit", new Sport());

        [HttpPost]
        public IActionResult DeleteSport(int SportID)
        {
            Sport deletedSport = repository.DeleteSport(SportID);
            if (deletedSport != null)
            {
                //TempData["message"] = $"{deletedSport.Name} was deleted";
            }
            return RedirectToAction("Sport");
        }

        [HttpPost]
        public IActionResult EditSportsBuilding(SportsBuilding sportsBuilding)
        {
            if (ModelState.IsValid)
            {
                repository.SaveSportsBuilding(sportsBuilding);
                return RedirectToAction("SportsBuilding");
            }
            else
            {
                // there is something wrong with the data values
                return View(sportsBuilding);
            }
        }

        public ViewResult CreateSportsBuilding() => View("SportsBuildingEdit", new SportsBuilding());

        [HttpPost]
        public IActionResult DeleteSportsBuilding(int SportsBuildingID)
        {
            SportsBuilding deletedSportsBuilding = repository.DeleteSportsBuilding(SportsBuildingID);
            if (deletedSportsBuilding != null)
            {
                //TempData["message"] = $"{deletedSportsBuilding.Name} was deleted";
            }
            return RedirectToAction("SportsBuilding");
        }

        [HttpPost]
        public IActionResult EditSportsHall(SportsHall sportsHall)
        {
            if (ModelState.IsValid)
            {
                repository.SaveSportsHall(sportsHall);
                return RedirectToAction("SportsHall");
            }
            else
            {
                // there is something wrong with the data values
                return View(sportsHall);
            }
        }

        public ViewResult CreateSportsHall() => View("SportsHallEdit", new SportsHall());

        [HttpPost]
        public IActionResult DeleteSportsHall(int SportsHallID)
        {
            SportsHall deletedSportsHall = repository.DeleteSportsHall(SportsHallID);
            if (deletedSportsHall != null)
            {
                //TempData["message"] = $"{deletedSportsHall.SportsHallID} was deleted";
            }
            return RedirectToAction("SportsHall");
        }
    }
}
