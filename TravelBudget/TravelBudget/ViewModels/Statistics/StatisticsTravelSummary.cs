using TravelBudgetDBModels.Models;

namespace TravelBudget.ViewModels.Statistics
{
    public class StatisticsTravelSummary
    {
        public string TableTitle { get; set; }
        public string FooterTitle { get; set; }
        public Travel DescribedTravel { get; set; } =  new Travel();
        public double TotalCost
        {
            get { return DescribedTravel.Expenses.Sum(e => e.Price?? 0);}
            private set { }
        }
        public string DurationTime
        {
            get
            {
                var timeSpan = (DescribedTravel.FinishDate - DescribedTravel.StartingDate);
                var time = $"{timeSpan.TotalDays} day(s) {timeSpan.TotalHours}h {timeSpan.TotalMinutes}min";
                return time;
            }
            private set { }
        }
        public string TotalCostWithCurrency { get { return (TotalCost.ToString() +" "+ DescribedTravel.Expenses.First().Country.Currency.Code); } }       
        public string SummaryTotal { get; set; }
    }
}
