using System.Collections.Generic;
using System.Linq;
using ExpenseTrackerApp.Models;

namespace ExpenseTrackerApp.Data
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ExpenseContext _context;

        // Constructor initializing the DbContext
        public ExpenseRepository(ExpenseContext context) => _context = context;

        // Get an expense by its ID
        public Expense? GetById(int id) => _context.Expenses.Find(id);

        // Get all expenses
        public List<Expense> GetAll() => _context.Expenses.ToList();

        // Add a new expense
        public bool Add(Expense expense)
        {
            _context.Expenses.Add(expense);
            return _context.SaveChanges() > 0;
        }

        // Update an existing expense
        public bool Update(Expense expense)
        {
            _context.Expenses.Update(expense);
            return _context.SaveChanges() > 0;
        }

        // Delete an expense by its ID
        public bool Delete(int id)
        {
            var expense = GetById(id);
            if (expense == null) return false;
            _context.Expenses.Remove(expense);
            return _context.SaveChanges() > 0;
        }

        // Get recent expenses for a specific user
        public List<Expense> GetRecentExpensesByUserId(int userId)
        {
            return _context.Expenses.Where(e => e.UserId == userId).ToList();
        }

        // Get expenses for a user within a specific date range
        public List<Expense> GetExpensesByDateRange(int userId, DateTime startDate, DateTime endDate)
        {
            return _context.Expenses
                .Where(e => e.UserId == userId && e.Date >= startDate && e.Date <= endDate)
                .ToList();
        }
    }
}
