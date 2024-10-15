// Data/ExpenseRepository.cs
using System.Collections.Generic;
using System.Linq;
using ExpenseTrackerApp.Models;

namespace ExpenseTrackerApp.Data
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ExpenseContext _context;

        // Use expression-bodied constructor
        public ExpenseRepository(ExpenseContext context) => _context = context;

        public Expense? GetById(int id) => _context.Expenses.Find(id);

        public List<Expense> GetAll() => _context.Expenses.ToList();

        public bool Add(Expense expense)
        {
            _context.Expenses.Add(expense);
            return _context.SaveChanges() > 0;
        }

        public bool Update(Expense expense)
        {
            _context.Expenses.Update(expense);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var expense = GetById(id);
            if (expense == null) return false;
            _context.Expenses.Remove(expense);
            return _context.SaveChanges() > 0;
        }

        public List<Expense> GetRecentExpensesByUserId(int userId)
        {
            return _context.Expenses.Where(e => e.UserId == userId).ToList();
        }

        // Additional methods like getting expenses by specific criteria
        public List<Expense> GetExpensesByDateRange(int userId, DateTime startDate, DateTime endDate)
        {
            return _context.Expenses
                .Where(e => e.UserId == userId && e.Date >= startDate && e.Date <= endDate)
                .ToList();
        }
    }
}
