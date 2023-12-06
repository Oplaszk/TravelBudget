using TravelBudgetDBModels.Models;

namespace TravelBudget.ViewModels
{
    public class TravelViewModel
    {
        public IEnumerable<Travel> Travels { get; set; }  
        public Travel Travel { get; set; } = new Travel();
    }
}
