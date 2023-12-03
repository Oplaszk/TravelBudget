using TravelBudgetDBModels.Models;

namespace TravelBudget.Models
{
    public class StatisticsViewModel
    {
        public IEnumerable<Travel> Travels { get; set; }
        public IEnumerable<Expense> Expenses { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public Travel TheMostExpensiveTravel { get; set; } = new Travel();
        public Travel TheCheapestTravel { get; set; } = new Travel();
    }
}
