using TravelBudgetDBModels.Models;

namespace TravelBudgetDBContact.Repositories.Interfaces
{
     public interface ITravelRepository
    {
        List<Travel> GetAllTravels(string userId, bool active);
        bool SaveTravelToDB(Travel travel, List<string> selectedCountryIds);
        Travel GetById(int id);
        bool UpdateTravel(Travel travel, List<string> selectedCountryIds);
        bool EndTravel(Travel travel);
        bool RetrieveTravel(Travel travel);
        bool DeleteTravel(Travel travel);
    }
}
