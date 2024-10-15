// Controllers/IncomeController.cs
using ExpenseTrackerApp.Models;
using ExpenseTrackerApp.Data;

namespace ExpenseTrackerApp.Controllers
{
    public class IncomeController
    {
        private readonly IIncomeRepository _incomeRepository;

        public IncomeController(IIncomeRepository incomeRepository)
        {
            _incomeRepository = incomeRepository;
        }

        public bool AddIncome(int userId, decimal amount, string source, DateTime date)
        {
            var income = new Income
            {
                Amount = amount,
                Source = source,
                Date = date,
                UserId = userId
            };

            return _incomeRepository.Add(income);
        }

        public bool UpdateIncome(int incomeId, decimal amount, string source, DateTime date)
        {
            var income = _incomeRepository.GetById(incomeId);
            if (income == null) return false;

            income.Amount = amount;
            income.Source = source;
            income.Date = date;

            return _incomeRepository.Update(income);
        }

        public bool DeleteIncome(int incomeId)
        {
            return _incomeRepository.Delete(incomeId);
        }
    }
}
