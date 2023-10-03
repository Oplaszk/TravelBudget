namespace TravelBudgetModels.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public Travel Travel { get; set; }
    }
}
