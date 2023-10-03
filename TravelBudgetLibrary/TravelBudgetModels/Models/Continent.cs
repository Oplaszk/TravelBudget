namespace TravelBudgetModels.Models
{
    public class Continent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Country> Countries { get; set; } = new List<Country>();  
    }
}
