using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using SporthalC3;
using SporthalC3.Domain;
using SporthalC3.ViewModels;
using SporthalC3.Models;


namespace SporthalC3.Controllers
{
    public class ReserveController : Controller
    {
        private ISportHalRepository repository;

        public ReserveController(ISportHalRepository repo)
        {
            repository = repo;
        }

        private SportsHall GetSportsHallByID(int SporthallID)
        {
            foreach(var x in repository.SportsHall)
            {
                if (x.SportsHallID == SporthallID)
                    return x;
            }

            return null;
        }

        private bool CheckReserve(ReserveViewModel reserveViewModel)
        {
            bool allreadyReserved = false;
            foreach(var p in repository.Reserve)
            {
                if(p.Datum == reserveViewModel.Reserve.Datum && p.StartTime == reserveViewModel.Reserve.StartTime && p.EndTime == reserveViewModel.Reserve.EndTime)
                {
                    allreadyReserved = true;
                }
            }
            return allreadyReserved;
        }

        public ViewResult ReserveStatus(ReserveViewModel reserveViewModel, int Tijdsduur, int Beginstijd, int SportHallID, DateTime Date)
        {
            if (reserveViewModel.Reserve.Datum != null &&
                reserveViewModel.Reserve.Email != null &&
                reserveViewModel.Reserve.FirstName != null &&
                reserveViewModel.Reserve.LastName != null &&
                reserveViewModel.Reserve.PhoneNumber != 0 &&
                SportHallID != 0 &&
                Tijdsduur != 0 &&
                Beginstijd != 0)
            {
                DateTime starttijd = new DateTime(1990, 1, 1, Beginstijd, 0 , 0);
                DateTime eindtijd = new DateTime(1990, 1, 1, Beginstijd + Tijdsduur, 0, 0);
                reserveViewModel.Reserve.SportsHall = GetSportsHallByID(SportHallID);
                reserveViewModel.Reserve.StartTime = starttijd;
                reserveViewModel.Reserve.EndTime = eindtijd;
                reserveViewModel.Reserve.Datum = Date;
                
                if(CheckReserve(reserveViewModel) != true)
                {
                    reserveViewModel.Reserve.Context = "Reservation";
                    repository.SaveReserve(reserveViewModel.Reserve);
                }
                    

                return View("ReservationStatus", reserveViewModel);
            }
            else
            {
                ViewBag.error = "De gegevens zijn niet juist ingevoerd";
                return ReserveTimePick(SportHallID, Date, Beginstijd, reserveViewModel, Tijdsduur);
            }
        }

        public ViewResult SearchView(string email, bool searched, string orderBy, string featureReserves)
        {
            ReserveViewModel reserveViewModel = new ReserveViewModel();
            reserveViewModel.ReserveList = repository.Reserve
                .Where(x => x.Email == email)
                .Where(x => featureReserves == null || featureReserves == "off" || x.Datum > DateTime.Now)
                .OrderBy(x => x.Datum)
                .ToList();
            reserveViewModel.Searched = searched;
            reserveViewModel.seachEmail = email;
            reserveViewModel.OrderBy = orderBy;
            if (featureReserves == "on")
                reserveViewModel.futureReserves = true;

            if(orderBy == "no")
            {
                reserveViewModel.ReserveList = reserveViewModel.ReserveList.OrderBy(x => x.Datum).Reverse().ToList();
            }

            return View("Search", reserveViewModel);
                
        }

        public ViewResult ReserveDatePick(int SportHallID)
        {
            return View("Date", GetSportsHallByID(SportHallID));
        }

        public ViewResult ReserveSummary(int SportHallID)
        {
            return View("ReserveSporthallSummary", GetSportsHallByID(SportHallID));
        }

        public ViewResult ReserveTimePick(int SportHallID, DateTime Date, int? TimeL, ReserveViewModel reserveViewModel, int? tijdsduur)
        {
            if(Date < DateTime.Now)
            {
                ViewBag.error = "Je kan alleen vooruit reserveren";
                return View("Date", GetSportsHallByID(SportHallID));
            }


            //Length = 1;
            //conert IEnum naar List
            List<Reserve> reserveList = new List<Reserve>();

            foreach (var x in repository.Reserve)
            {
                reserveList.Add(x);
            }

            //fake data
            

            //Lijst filteren op de datum en sportshallID
            ReserveViewModel model = new ReserveViewModel();
            model.ReserveList = reserveList
                .OrderBy(x => x.ReserveID)
                .Where(x => x.SportsHall.SportsHallID == SportHallID)
                .Where(x => x.Datum == Date)
                .ToList();




            //TijdLijst maken                                  
            List<int> TimeList = new List<int>();
            for (int Time = repository.SportsHall.Where(x => x.SportsHallID == SportHallID).Select(x => x.OpenTime.Hour).FirstOrDefault(); Time < repository.SportsHall.Where(x => x.SportsHallID == SportHallID).Select(x => x.CloseTime.Hour).FirstOrDefault(); Time++)
                
            {                              
                if (repository.Reserve.Where(x=>x.SportsHall.SportsHallID == SportHallID).Where(x=>x.Datum == Date).Where(x=>x.StartTime.Hour == Time).OrderBy(x=>x.StartTime).Select(x=>x.StartTime.Hour).FirstOrDefault() != 0 )
                {
                    //Voeg geen tijd toe                   
                }else 
                if(repository.Reserve.OrderBy(x => x.ReserveID).Where(x=>x.SportsHall.SportsHallID == SportHallID).Where(x => x.Datum == Date).Where(x => x.StartTime.Hour < Time).Where(x => x.EndTime.Hour > Time).Select(x => x.ReserveID).FirstOrDefault() != 0)
                {
                    //Voeg geen tijd toe
                }
                    else
                    {
                        //Voeg tijd toe
                        TimeList.Add(Time);
                    }
            }

            //TijdSpanLijst maken
            List<int> TimeSpanList = new List<int>();
            

            int y;
            if (repository.Reserve.Where(z => z.Datum == Date).Where(x => x.StartTime.Hour > TimeL).OrderBy(x => x.StartTime).Select(x => x.StartTime.Hour).FirstOrDefault() == 0)
            {
                y = repository.SportsHall.Where(x => x.SportsHallID == SportHallID).Select(x => x.CloseTime.Hour).FirstOrDefault();
            }
            else
            {

                y = repository.Reserve.Where(z=>z.Datum == Date).Where(x => x.StartTime.Hour > TimeL).OrderBy(x => x.StartTime).Select(x => x.StartTime.Hour).FirstOrDefault();
            }

            
            if (TimeL != null)
            {
                int Hour = 0;

                for ( int? length = TimeL;length < y; length++)
                {
                    Hour = Hour + 1;
                    TimeSpanList.Add(Hour);

                }

            }
            model.TimeSpanList = TimeSpanList;
            model.TimeList = TimeList;
            model.Date = Date;
            model.SporthallID = SportHallID;
            model.SportsHall = GetSportsHallByID(SportHallID);
            model.TimeL = TimeL.GetValueOrDefault();
            model.Reserve = new Reserve();

            if (reserveViewModel.Reserve != null)
            {
                model.Reserve.FirstName = reserveViewModel.Reserve.FirstName;
                model.Reserve.LastName = reserveViewModel.Reserve.LastName;
                model.Reserve.PhoneNumber = reserveViewModel.Reserve.PhoneNumber;
                model.Reserve.Email = reserveViewModel.Reserve.Email;
                model.Tijdsduur = reserveViewModel.Tijdsduur;
            }
            
            return View("NaamInvul", model);
        }
    }
}
