using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBudgetDBModels.Models
{
    public class Currency
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public ICollection<Country> Countries { get; set; }
    }
}
