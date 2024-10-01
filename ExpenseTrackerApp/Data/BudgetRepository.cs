using System;
using System.Linq;
using ExpenseTrackerApp.Data;
using ExpenseTrackerApp.Models;

namespace ExpenseTrackerApp.Data
{
    public class BudgetRepository
    {
        private readonly ExpenseContext _context;

        public BudgetRepository(ExpenseContext context)
        {
            _context = context;
        }

        // Method to add or update a user's budget
        public void AddOrUpdateBudget(Budget budget)
        {
            var existingBudget = _context.Budgets.SingleOrDefault(b => b.UserId == budget.UserId);
            if (existingBudget != null)
            {
                existingBudget.TotalBudget = budget.TotalBudget;
                existingBudget.RemainingBudget = budget.RemainingBudget;
                _context.SaveChanges();
            }
            else
            {
                _context.Budgets.Add(budget);
                _context.SaveChanges();
            }
        }

        // Method to get the budget for a user by user ID
        public Budget GetBudgetByUserId(int userId)
        {
            return _context.Budgets.SingleOrDefault(b => b.UserId == userId);
        }

        // Method to update the remaining budget after an expense
        public void UpdateRemainingBudget(int userId, decimal amount)
        {
            var budget = _context.Budgets.SingleOrDefault(b => b.UserId == userId);
            if (budget != null)
            {
                budget.RemainingBudget -= amount;
                _context.SaveChanges();
            }
        }

        // Method to reset the budget at the end of the month
        public void ResetBudgetAtEndOfMonth(int userId)
        {
            var budget = _context.Budgets.SingleOrDefault(b => b.UserId == userId);
            if (budget != null)
            {
                budget.RemainingBudget = budget.TotalBudget;
                _context.SaveChanges();
            }
        }
    }
}
