using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBudgetDBModels.Models;

namespace TravelBudgetDBContact.Repositories.Interfaces
{
     public interface ITravelRepository
    {
        List<Travel> GetAllTravels(string userId, bool active);
        bool SaveTravelToDB(Travel travel, List<string> selectedCountryIds);
        Travel GetById(int id);
        bool UpdateTravel(Travel travel);
        bool DeleteTravel(Travel travel);
        bool EndTravel(Travel travel);
        bool RetrieveTravel(Travel travel);
    }
}
