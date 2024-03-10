using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TravelBudget.ViewModels;
using TravelBudget.ViewModels.Enums;
using TravelBudgetDBContact.Repositories.Interfaces;

namespace TravelBudget.Controllers
{
    public class ExpenseController(IExpenseRepository expenseRepository, ICategoryRepository categoryRepository, ICountryRepository countryRepository,
    ILogger<ExpenseController> logger, IMapper mapper) : BaseController(logger, mapper)
    {
        private readonly ExpenseViewModel _expenseViewModel = new ExpenseViewModel();

        #region CREATE Section
        [HttpGet]
        public IActionResult AddExpense(int id)
        {
            _expenseViewModel.CategoryOptions = categoryRepository.GetAllCategories();
            _expenseViewModel.Countries = countryRepository.GetAllCountriesDTO();
            _expenseViewModel.TravelId = id;

            return View("AddExpense", _expenseViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddExpense(ExpenseViewModel expenseViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int Id = expenseViewModel.TravelId;
                    expenseViewModel.Expense.TravelId = Id;

                    expenseRepository.SaveExpenseToDB(expenseViewModel.Expense);
                    PopUpNotification("Expense has been added successfully", notificationType: NotificationType.success);

                    return RedirectToAction("AddExpense", "Expense", new { id = Id });
                }
            }
            catch (Exception)
            {
                PopUpNotification("Error occurred while adding expense to the travel", notificationType: NotificationType.error);
            }

            expenseViewModel.CategoryOptions = categoryRepository.GetAllCategories();
            expenseViewModel.Countries = countryRepository.GetAllCountriesDTO();

            return View("AddExpense", expenseViewModel);
        }

        #endregion CREATE Section

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var expenseToDetele = expenseRepository.GetAllExpenses().Single(e => e.Id == id);
                expenseRepository.DeleteExpense(expenseToDetele);
                int travelId = expenseToDetele.TravelId;

                return RedirectToAction("Details", "Detail", new { Id = travelId });
            }
            catch (Exception)
            {
                PopUpNotification("Error occurred while deleting expense", notificationType: NotificationType.error);
            }

            return Ok();
        }

        #region UPDATE Section

        [HttpGet]
        public IActionResult Update(int id)
        {
            var expenseToUpdate = expenseRepository.GetExpenseById(id);

            var viewModel = new ExpenseViewModel
            {
                Expense = expenseToUpdate,
                CategoryOptions = categoryRepository.GetAllCategories(),
                Countries = countryRepository.GetAllCountriesDTO(),
                TravelId = expenseToUpdate.TravelId
            };

            return View("AddExpense", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ExpenseViewModel expenseToUpdate)
        {
            try
            {
                int travelId = expenseToUpdate.TravelId;
                expenseToUpdate.Expense.TravelId = travelId;

                expenseRepository.UpdateExpense(expenseToUpdate.Expense);

                PopUpNotification("Your expense has been updated successfully");

                return RedirectToAction("Details", "Detail", new { id = travelId });
            }

            catch (Exception)
            {
                PopUpNotification("Error occurred while updating expense to the travel", notificationType: NotificationType.error);
            }
            
            return RedirectToAction("Update", "Expense", expenseToUpdate.Expense.Id);
        }
        #endregion UPDATE Section
    }
}
