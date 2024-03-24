using TravelBudgetDBModels.Models;

namespace TravelBudgetDBContact.Repositories.Interfaces
{
     public interface ITravelRepository
    {
        List<Travel> GetAllTravels(string userId, bool active);
        bool SaveTravelToDB(Travel travel, List<int> selectedCountryIds);
        Travel GetTravelById(int id);
        bool UpdateTravel(Travel travel, ICollection<int> selectedCountryIds);
        bool EndTravel(Travel travel);
        bool RetrieveTravel(Travel travel);
        bool DeleteTravel(Travel travel);
    }
}
