namespace TravelBudget.Models
{
    public class Expenses
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public DateTime Date { get; set; } = new DateTime();
        public int Category_Id { get; set; }
        public int Country_Id { get; set; }
        public int Travel_Id { get; set; }
    }
}
