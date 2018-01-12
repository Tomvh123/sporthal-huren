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

        IEnumerable<Reserve> GetReservesById(int SportHallID, DateTime date);

        IEnumerable<Reserve> GetReservesByIdAndEmail(int SportHallID, string email);

        IEnumerable<IEnumerable<Reserve>> GetReservesByWeek(int SportHallID, DateTime monday, DateTime sunday);


        IEnumerable<SportsBuildingAdministrator> SportsBuildingAdministrator { get; }

        IEnumerable<SportsBuildingAdministrator> SportsBuildingAdministratorOnly { get; }

        void DeleteSportsBuildingAdministratorAPI();

        void SaveSportsBuildingAdministrator(SportsBuildingAdministrator sportsBuildingAdministrator);

        void SaveSportsBuildingAdministratorAPI(SportsBuildingAdministrator sportsBuildingAdministrator);

        SportsBuildingAdministrator DeleteSportsBuildingAdministrator(int sportsBuildingAdministratorID);


        IEnumerable<SportsBuilding> SportsBuilding { get; }

        IEnumerable<SportsBuilding> SportsBuildingOnly { get; }

        void DeleteSportsBuildingAPI();

        void SaveSportsBuilding(SportsBuilding sportsBuilding);

        void SaveSportsBuildingAPI(SportsBuilding sportsBuilding);

        SportsBuilding DeleteSportsBuilding(int sportsBuildingID);


        IEnumerable<SportsHall> SportsHall { get; }

        void DeleteSportsHallAPI();

        IEnumerable<SportsHall> SportsHallOnly();

        void SaveSportsHall(SportsHall sportsHall);

        void SaveSportsHallAPI(SportsHall SportsHall);

        SportsHall DeleteSportsHall(int sportsHallID);


        IEnumerable<SportsHallSports> SportsHallSports { get; }


        IEnumerable<Sport> Sport { get; }

        void DeleteSportAPI();

        void SaveSport(Sport sport);

        void SaveSportAPI(Sport sport);

        Sport DeleteSport(int sportID);
    }
}
