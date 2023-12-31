﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBudgetDBModels.Models;

namespace TravelBudgetDBContact.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        public List<Category> GetAllCategories();
        public bool CreateNewCategory(Category model);
        public bool DeleteCategory(Category model);
    }
}
