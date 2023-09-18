using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBudgetModels.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int ContinentId { get; set; }
        public int CurrencyId { get; set; }
        public Continent Continent { get; set; }
        public Currency Currency { get; set; }
        public ICollection<Travel> Travels { get; set; }

    }
}
