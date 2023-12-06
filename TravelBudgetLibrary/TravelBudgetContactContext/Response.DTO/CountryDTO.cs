using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBudgetDBContact.Response.DTO
{
    public class CountryDTO
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public string ContinentName { get; set; }
        public string Code { get; set; }
        public string CountryWithCode { get { return (CountryName + $"({Code})"); } }
    }
}
