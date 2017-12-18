using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SporthalC3.Models;

namespace SporthalC3.Domain
{
    public interface ISportHalRepository
    {


        IEnumerable<Reserve> Reserve { get; }

        void SaveReserve(Reserve reserve);

        Reserve DeleteReserve(int reserveID);

        IEnumerable<SportsBuildingAdministrator> SportsBuildingAdministrator { get; }

        IEnumerable<SportsBuildingAdministrator> SportsBuildingAdministratorOnly { get; }

        void SaveSportsBuildingAdministrator(SportsBuildingAdministrator sportsBuildingAdministrator);

        SportsBuildingAdministrator DeleteSportsBuildingAdministrator(int sportsBuildingAdministratorID);


        IEnumerable<SportsBuilding> SportsBuilding { get; }

        IEnumerable<SportsBuilding> SportsBuildingOnly { get; }


        void SaveSportsBuilding(SportsBuilding sportsBuilding);

        SportsBuilding DeleteSportsBuilding(int sportsBuildingID);


        IEnumerable<SportsHall> SportsHall { get; }

        IEnumerable<SportsHall> SportsHallOnly { get; }

        void SaveSportsHall(SportsHall sportsHall);

        SportsHall DeleteSportsHall(int sportsHallID);


        IEnumerable<SportsHallSports> SportsHallSports { get; }


        IEnumerable<Sport> Sport { get; }

        void SaveSport(Sport sport);

        Sport DeleteSport(int sportID);
    }
}
