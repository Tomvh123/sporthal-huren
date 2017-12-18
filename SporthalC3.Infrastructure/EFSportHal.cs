using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SporthalC3;
using SporthalC3.Domain;
using SporthalC3.Models;

namespace SporthalC3
{
    public class EFSportHal : ISportHalRepository
    {
        private ApplicationDbContext context;

        public EFSportHal(ApplicationDbContext ctx)
        {
            context = ctx;

        }

        public IEnumerable<Reserve> Reserve => context.Reserve.Include(x=>x.SportsHall).ThenInclude(y => y.SportsBuilding).ThenInclude(f => f.SportsBuildingAdministrator);

        public Reserve DeleteReserve(int reserveID)
        {
            Reserve dbEntry = context.Reserve.FirstOrDefault(p => p.ReserveID == reserveID);
            if(dbEntry != null)
            {
                context.Reserve.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;

        }

        public void SaveReserve(Reserve reserve)
        {
            if (reserve.ReserveID == 0)
            {
                context.Reserve.Add(reserve);
            }
            else
            {
                Reserve dbEntry = context.Reserve.FirstOrDefault(p => p.ReserveID == reserve.ReserveID);
                if (dbEntry != null)
                {
                    dbEntry.FirstName = reserve.FirstName;
                    dbEntry.LastName = reserve.LastName;
                    dbEntry.PhoneNumber = reserve.PhoneNumber;
                    dbEntry.StartTime = reserve.StartTime;
                    dbEntry.EndTime = reserve.EndTime;
                    
                }
            }
            context.SaveChanges();
        }

        //public IEnumerable<SportsHall> SportsHall =>

        public IEnumerable<SportsBuildingAdministrator> SportsBuildingAdministrator =>
        context.SportsBuildingAdministrators.Include(a => a.SportBuildingList).ThenInclude(b => b.SportsHallList).ThenInclude(c => c.SportsHallSports).ThenInclude(d => d.Sport);

        public SportsBuildingAdministrator DeleteSportsBuildingAdministrator(int sportsBuildingAdministratorID)
        {
            SportsBuildingAdministrator dbEntry = context.SportsBuildingAdministrators.FirstOrDefault(p => p.SportsBuildingAdministratorID == sportsBuildingAdministratorID);

            if(dbEntry != null)
            {
                context.SportsBuildingAdministrators.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }

        public void SaveSportsBuildingAdministrator(SportsBuildingAdministrator sportsBuildingAdministrator)
        {
            if(sportsBuildingAdministrator.SportsBuildingAdministratorID == 0)
            {
                context.SportsBuildingAdministrators.Add(sportsBuildingAdministrator);
            }
            else
            {
                SportsBuildingAdministrator dbEntry = context.SportsBuildingAdministrators.FirstOrDefault(p => p.SportsBuildingAdministratorID == sportsBuildingAdministrator.SportsBuildingAdministratorID);
                if(dbEntry != null)
                {
                    dbEntry.FirstName = sportsBuildingAdministrator.FirstName;
                    dbEntry.LastName = sportsBuildingAdministrator.LastName;
                }
            }
            context.SaveChanges();
        }

        public IEnumerable<SportsBuilding> SportsBuilding => context.SportsBuilding;

        public SportsBuilding DeleteSportsBuilding(int SportsBuildingID)
        {
            SportsBuilding dbEntry = context.SportsBuilding.FirstOrDefault(p => p.SportsBuildingID == SportsBuildingID);

            if (dbEntry != null)
            {
                context.SportsBuilding.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }

        public void SaveSportsBuilding(SportsBuilding sportsBuilding)
        {
            if (sportsBuilding.SportsBuildingID == 0)
            {
                context.SportsBuilding.Add(sportsBuilding);
            }
            else
            {
                SportsBuilding dbEntry = context.SportsBuilding.FirstOrDefault(p => p.SportsBuildingID == sportsBuilding.SportsBuildingID);
                if (dbEntry != null)
                {
                    dbEntry.Name = sportsBuilding.Name;
                    dbEntry.HouseNumber = sportsBuilding.HouseNumber;
                    dbEntry.City = sportsBuilding.City;
                    dbEntry.PostalCode = sportsBuilding.PostalCode;
                    dbEntry.Street = sportsBuilding.Street;
                }
            }
            context.SaveChanges();
        }

        public IEnumerable<SportsHall> SportsHall => context.SportsHall.Include(x => x.SportsBuilding).ThenInclude(x => x.SportsBuildingAdministrator).Include(a => a.Reserve).Include(x => x.SportsHallSports).ThenInclude(x => x.Sport);

        

        public SportsHall DeleteSportsHall(int SportsHallID)
        {
            SportsHall dbEntry = context.SportsHall.FirstOrDefault(p => p.SportsHallID == SportsHallID);

            if (dbEntry != null)
            {
                context.SportsHall.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }

        public void SaveSportsHall(SportsHall SportsHall)
        {
            if (SportsHall.SportsHallID == 0)
            {
                context.SportsHall.Add(SportsHall);
            }
            else
            {
                SportsHall dbEntry = context.SportsHall.FirstOrDefault(p => p.SportsHallID == SportsHall.SportsHallID);
                if (dbEntry != null)
                {
                    dbEntry.Length = SportsHall.Length;
                    dbEntry.NumberOfDressingSpace = SportsHall.NumberOfDressingSpace;
                    dbEntry.NumberOfShowers = SportsHall.NumberOfShowers;
                    dbEntry.Width = SportsHall.Width;
                }
            }
            context.SaveChanges();
        }

        public IEnumerable<SportsHallSports> SportsHallSports => context.SportHallSports;

        public IEnumerable<Sport> Sport => context.Sport;

        public IEnumerable<SportsHall> SportsHallOnly => context.SportsHall;

        public IEnumerable<SportsBuildingAdministrator> SportsBuildingAdministratorOnly => context.SportsBuildingAdministrators;

        public IEnumerable<SportsBuilding> SportsBuildingOnly => context.SportsBuilding;

        public Sport DeleteSport(int SportID)
        {
            Sport dbEntry = context.Sport.FirstOrDefault(p => p.SportID == SportID);

            if (dbEntry != null)
            {
                context.Sport.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }

        public void SaveSport(Sport Sport)
        {
            if (Sport.SportID == 0)
            {
                context.Sport.Add(Sport);
            }
            else
            {
                Sport dbEntry = context.Sport.FirstOrDefault(p => p.SportID == Sport.SportID);
                if (dbEntry != null)
                {
                    dbEntry.Name = Sport.Name;
                }
            }
            context.SaveChanges();
        }
    }
}
