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
    public class HomeController : Controller
    {
        private ISportHalRepository repository;

        public HomeController(ISportHalRepository repo)
        {
            repository = repo;
        }

        public ViewResult Disclaimer() => View();
        public ViewResult Index()
        {
            IndexViewModel model = new IndexViewModel();
            model.sportList = repository.Sport.ToList();
            model.sportBuildingList = repository.SportsBuilding.ToList();
            return View(model);
        }

        public ViewResult Maps()
        {
            return View();
        }
    }
}

