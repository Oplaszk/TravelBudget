namespace TravelBudgetModels.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; } = new DateTime();
        public int CategoryId { get; set; }
        public int TravelId { get; set; }
        public int CountryId { get; set; } // Tutaj chyba nie potrzebuję bo mam dostęp z Travel, tak?
        public ICollection<Category> Categories { get; set; }
        public Travel Travel { get; set; }
        public Country Country { get; set; } // Tutaj chyba nie potrzebuję bo mam dostęp z Travel, tak?
    }
}
