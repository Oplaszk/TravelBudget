namespace TravelBudgetModels.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Travel Travel { get; set; }
    }
}
