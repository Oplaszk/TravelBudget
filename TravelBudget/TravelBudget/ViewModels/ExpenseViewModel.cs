﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using TravelBudgetDBContact.Response.DTO;
using TravelBudgetDBModels.Models;

namespace TravelBudget.ViewModels
{
    public class ExpenseViewModel
    {
        public Expense Expense { get; set; } = new Expense();
        public IEnumerable<Expense>? Expenses { get; set; }
        public IEnumerable<Category>? CategoryOptions { get; set; }
        public IEnumerable<CountryDTO>? Countries { get; set; }
        public int TravelId { get; set; }
    }
}
