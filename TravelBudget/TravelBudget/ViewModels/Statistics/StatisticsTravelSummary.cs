using TravelBudgetDBModels.Models;

namespace TravelBudget.ViewModels.Statistics
{
    public class StatisticsTravelSummary
    {
        public string TableTitle { get; set; }
        public string FooterTitle { get; set; }
        public Travel DescribedTravel { get; set; } =  new Travel();
        //public Currency Currency { get; set; } = new Currency();
        //public string CurrencyCode 
        //{
        //    get { return DescribedTravel; }

        //    private set { } 
        //}
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
                var time = $"{timeSpan.Days} day(s) {timeSpan.Hours}h {timeSpan.Minutes}min";
                return time;
            }
            private set { }
        }
        public string TotalCostWithCurrency { get { return (TotalCost.ToString("C") + DescribedTravel.Expenses.First().CurrencyCode); } }       
        public string SummaryTotal { get; set; }
    }
}
