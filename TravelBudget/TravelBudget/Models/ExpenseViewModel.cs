using System.ComponentModel;
using TravelBudgetContactContext.Response.DTO;
using TravelBudgetModels.Models;

namespace TravelBudget.Models
{
    public class ExpenseViewModel
    {
        public Expense Expense { get; set; } = new Expense();
        public IEnumerable<Expense> Expenses { get; set; }
        public IEnumerable<Category> CategoryOptions { get; set; }
        public IEnumerable<CountryDTO> Countries { get; set; }
        public int TravelId { get; set; }
        //public string NamePlusCode { get { return () }; }
    }
}
