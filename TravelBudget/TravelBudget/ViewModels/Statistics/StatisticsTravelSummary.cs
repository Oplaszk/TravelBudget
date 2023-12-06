using TravelBudgetDBModels.Models;

namespace TravelBudget.ViewModels.Statistics
{
    public class StatisticsTravelSummary
    {
        public string TableTitle { get; set; }
        public string FooterTitle { get; set; }
        public Travel DescribedTravel { get; set; }
        public double TotalCost { get; set; }
        public Currency Currency { get; set; } = new Currency();
        public string TotalCostWithCurrency { get { return TotalCost.ToString("C") + "" + Currency.Code; } }
        public string DurationTime { get; set; }

    }
}
