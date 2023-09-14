namespace TravelBudgetModels.Models
{
    public class Continent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Country Countries { get; set; }
    }
}
