using TravelBudgetDBModels.Models;

namespace TravelBudget.Models
{
    public class StatisticsViewModel
    {
        public IEnumerable<Travel> Travels { get; set; }
        public IEnumerable<Expense> Expenses { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
