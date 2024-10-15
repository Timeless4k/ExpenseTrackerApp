// Controllers/ExpenseController.cs
using ExpenseTrackerApp.Models;
using ExpenseTrackerApp.Data;

namespace ExpenseTrackerApp.Controllers
{
    public class ExpenseController
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseController(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public bool AddExpense(int userId, string name, decimal amount, string category, DateTime date)
        {
            var expense = new Expense
            {
                Name = name,
                Amount = amount,
                Category = category,
                Date = date,
                UserId = userId
            };

            return _expenseRepository.Add(expense);
        }

        public bool UpdateExpense(int expenseId, string name, decimal amount, string category, DateTime date)
        {
            var expense = _expenseRepository.GetById(expenseId);
            if (expense == null) return false;

            expense.Name = name;
            expense.Amount = amount;
            expense.Category = category;
            expense.Date = date;

            return _expenseRepository.Update(expense);
        }

        public bool DeleteExpense(int expenseId)
        {
            return _expenseRepository.Delete(expenseId);
        }
    }
}
