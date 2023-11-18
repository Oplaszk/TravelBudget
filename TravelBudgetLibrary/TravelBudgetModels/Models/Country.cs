using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBudgetModels.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        [ForeignKey("ContinentId")]
        public int ContinentId { get; set; } // Klucz obcy
        public Continent Continent { get; set; } // Wartość nawigacyjna

        [ForeignKey("CurrencyId")] 
        public int CurrencyId { get; set; } // Klucz obcy
        public Currency Currency { get; set; } // Wartość nawigacyjna
        public ICollection<Travel> Travels { get; set; }
    }
}
