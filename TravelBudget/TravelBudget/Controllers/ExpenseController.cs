using Microsoft.AspNetCore.Mvc;
using TravelBudget.ViewModels;
using TravelBudget.ViewModels.Enums;
using TravelBudgetDBContact.Repositories.Interfaces;
using TravelBudgetDBModels.Models;

namespace TravelBudget.Controllers
{
    public class ExpenseController : BaseController
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ExpenseViewModel _expenseViewModel;

        public ExpenseController(IExpenseRepository expenseRepository, ICategoryRepository categoryRepository, ICountryRepository countryRepository, ILogger<ExpenseController> logger) : base(logger)
        {
            _expenseRepository = expenseRepository;
            _categoryRepository = categoryRepository;
            _countryRepository = countryRepository;
            _expenseViewModel = new ExpenseViewModel();
        }

        #region CREATE Section
        [HttpGet]
        public IActionResult AddExpense(int id)
        {
            _expenseViewModel.CategoryOptions = _categoryRepository.GetAllCategories();
            _expenseViewModel.Countries = _countryRepository.GetAllCountriesDTO();
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

                    _expenseRepository.SaveExpenseToDB(expenseViewModel.Expense);

                    return RedirectToAction("AddExpense", "Expense", new { id = Id });
                }
            }
            catch (Exception)
            {
                Notify("Error occurred while adding expense to the travel", notificationType: NotificationType.error);
            }

            expenseViewModel.CategoryOptions = _categoryRepository.GetAllCategories();
            expenseViewModel.Countries = _countryRepository.GetAllCountriesDTO();

            return View("AddExpense", expenseViewModel);
        }

        #endregion CREATE Section

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var expenseToDetele = _expenseRepository.GetAllExpenses().Single(e => e.Id == id);
                _expenseRepository.DeleteExpense(expenseToDetele);
                int travelId = expenseToDetele.TravelId;

                return RedirectToAction("Details", "Detail", new { Id = travelId });
            }
            catch (Exception)
            {
                Notify("Error occurred while deleting expense", notificationType: NotificationType.error);
            }

            return Ok();
        }

        #region UPDATE Section

        [HttpGet]
        public IActionResult Update(int id)
        {
            var expenseToUpdate = _expenseRepository.GetExpenseById(id);

            var viewModel = new ExpenseViewModel
            {
                Expense = expenseToUpdate,
                CategoryOptions = _categoryRepository.GetAllCategories(),
                Countries = _countryRepository.GetAllCountriesDTO(),
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

                _expenseRepository.UpdateExpense(expenseToUpdate.Expense);

                Notify("Your expense has been updated successfully");

                return RedirectToAction("Details", "Detail", new { id = travelId });
            }

            catch (Exception)
            {
                Notify("Error occurred while updating expense to the travel", notificationType: NotificationType.error);
            }
            
            return RedirectToAction("Update", "Expense", expenseToUpdate.Expense.Id);
        }
        #endregion UPDATE Section
    }
}
