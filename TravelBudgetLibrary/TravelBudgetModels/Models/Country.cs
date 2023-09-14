﻿namespace TravelBudgetModels.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public int ContinentId { get; set; }
        public int CurrencyId { get; set; }
        public Continent Continent { get; set; }
        public Currency Currency { get; set; }
    }
}
