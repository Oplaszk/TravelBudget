using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TravelBudgetDBContact.Repositories.Interfaces;
using TravelBudgetDBModels.Models;

namespace TravelBudgetDBContact.Repositories
{
    public class TravelRepository : BaseRepository, ITravelRepository
    {
        public TravelRepository(DBContact db, ILogger<TravelRepository> logger, IMapper mapper) : base(db, logger, mapper)
        {
        }
        public List<Travel> GetAllTravels(string userId, bool active)
        {
            try
            {
                return  _db.Travels.Include(t => t.Countries).Where(t => t.UserId == userId && t.Active == active).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving travels from the database.");
                return new List<Travel>();
            }
        }
        public bool SaveTravelToDB(Travel travel, List<int> selectedCountriesId)
        {
            try
            {

                if (selectedCountriesId != null && selectedCountriesId.Any())
                {
                    var CountriesToSave = _db.Countries.Where(c => selectedCountriesId.Contains(c.Id)).ToList();
                    travel.Countries = CountriesToSave;
                    _db.Travels.Add(travel);
                    _db.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving the travel to the database");
                return false;
            }
        }
        public Travel GetTravelById(int? id)
        {
            try
            {
                var travel = _db.Travels.Include(t => t.Countries).Where(a => a.Id == id).FirstOrDefault();

                return travel?? new Travel();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving travel from the database.");
                return new Travel();
            }
        }
        public bool UpdateTravel(Travel travel, ICollection<int> selectedCountries)
        {
            try
            {               
                if (selectedCountries != null && selectedCountries.Any() && travel!= null)
                {
                    var travelToUpdate = GetTravelById(travel.Id);
                    var CountriesToUpdate = _db.Countries.Where(c => selectedCountries.Contains(c.Id)).ToList();
                    travelToUpdate.Countries = CountriesToUpdate;
                    
                    _db.Travels.Update(travelToUpdate);
                    _db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating travel from the database.");
                return false;
            }
        }
        public bool DeleteTravel(Travel travel)
        {
            try
            {
                foreach (var country in travel.Countries.ToList())
                {
                    travel.Countries.Remove(country);
                }

                _db.Travels.Remove(travel);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting travel from the database.");
                return false;
            }
        }
        public bool EndTravel(Travel travel)
        {
            try
            {
                travel.Active = false;
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while moving the travel to History Travels.");
                return false;
            }
        }
        public bool RetrieveTravel(Travel travel)
        {
            try
            {
                travel.Active = true;
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retriving the travel from Travels History to Current Travels.");
                return false;
            }
            
        }

    }
}


