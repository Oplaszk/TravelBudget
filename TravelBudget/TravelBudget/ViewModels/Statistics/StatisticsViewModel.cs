using TravelBudgetDBModels.Models;

namespace TravelBudget.ViewModels.Statistics
{
    public class StatisticsViewModel
    {
        public StatisticsTravelSummary TheMostExpensiveTravel { get; set; } 
        = new StatisticsTravelSummary { TableTitle = "The Most Expensive Travel", FooterTitle = "Total Cost" };
        public StatisticsTravelSummary TheCheapestTravel { get; set; } 
        = new StatisticsTravelSummary { TableTitle = "The Cheapest Travel", FooterTitle = "Total Cost" };
        public StatisticsTravelSummary TheLongestTravel { get; set; } 
        = new StatisticsTravelSummary { TableTitle = "The Longest Travel", FooterTitle = "DurationTime" };
        public StatisticsTravelSummary TheShortestTravel { get; set; }
        = new StatisticsTravelSummary { TableTitle = "The Shortest Travel", FooterTitle = "Duration Time" };
        public List<Country> Countries { get; set; } = new List<Country>();
    }
}
