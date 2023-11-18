using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBudgetContactContext.Response.DTO
{
    public class ExpenseDTO
{
    public int Id { get; set; }
    public double Price { get; set; }
    public string CurrencyCode { get; set; }
    public string CountryCode { get; set; }
}
}

