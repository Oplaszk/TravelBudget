namespace TravelBudgetModels.Models
{
    public class Currency
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
