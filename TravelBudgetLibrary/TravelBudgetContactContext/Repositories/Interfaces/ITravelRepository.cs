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
        public List<Travel> GetAllTravels();
        public bool SaveTravelToDB(Travel travel);
        public Travel GetById(int id);
        public bool UpdateTravel(Travel travel);
        public bool DeleteTravel(Travel travel);
        public bool EndTravel(Travel travel);
        public bool RetrieveTravel(Travel travel);
    }
}
