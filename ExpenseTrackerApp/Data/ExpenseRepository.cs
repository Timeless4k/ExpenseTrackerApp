using System;
using System.Collections.Generic;
using System.Linq;
using ExpenseTrackerApp.Data;
using ExpenseTrackerApp.Models;

namespace ExpenseTrackerApp.Data
{
    public class ExpenseRepository
    {
        private readonly ExpenseContext _context;

        public ExpenseRepository(ExpenseContext context)
        {
            _context = context;
        }

        // Method to add a new expense for a user
        public void AddExpense(Expense expense)
        {
            _context.Expenses.Add(expense);
            _context.SaveChanges();
        }

        // Method to get recent expenses by user ID (limit to last 10 expenses, for example)
        public List<Expense> GetRecentExpensesByUserId(int userId)
        {
            return _context.Expenses
                           .Where(e => e.UserId == userId)
                           .OrderByDescending(e => e.Date)
                           .Take(10)  // Limit to the 10 most recent expenses
                           .ToList();
        }

        // Method to delete an expense by its ID
        public bool DeleteExpense(int expenseId)
        {
            var expense = _context.Expenses.SingleOrDefault(e => e.Id == expenseId);
            if (expense != null)
            {
                _context.Expenses.Remove(expense);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        // Method to update an existing expense
        public bool UpdateExpense(Expense updatedExpense)
        {
            var existingExpense = _context.Expenses.SingleOrDefault(e => e.Id == updatedExpense.Id);
            if (existingExpense != null)
            {
                existingExpense.Name = updatedExpense.Name;
                existingExpense.Amount = updatedExpense.Amount;
                existingExpense.Category = updatedExpense.Category;
                existingExpense.Date = updatedExpense.Date;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
