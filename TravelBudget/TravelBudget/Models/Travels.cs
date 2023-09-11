namespace TravelBudget.Models
{
    public class Travels
    {
        public int Id { get; set; }
        public DateTime Starting_Date { get; set; } = new DateTime();
        public DateTime Finish_Date { get; set; } = new DateTime();
        public string Travel_Name { get; set; }
        public string? Travel_Description { get; set; }
        public bool Active { get; set; }
        public int User_Id{ get; set; }
        public int Comment_Id { get; set; }

    }
}
