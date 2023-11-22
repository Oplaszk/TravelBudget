using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBudgetModels.Models;

namespace TravelBudgetContactContext.Repositories.Interfaces
{
    public interface IManagementRepository
    {
        public bool CreateNewCategory(Category model);
    }
}
