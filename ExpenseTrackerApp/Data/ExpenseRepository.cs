using System;
using System.Collections.Generic;
using System.Linq;
using ExpenseTrackerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerApp.Data
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ExpenseContext _context;

        // Constructor initializing the DbContext
        public ExpenseRepository(ExpenseContext context)
        {
            _context = context;
        }

        // Get an expense by its ID
        public Expense? GetById(int id)
        {
            return _context.Expenses.Find(id);
        }

        // Get all expenses
        public List<Expense> GetAll()
        {
            return _context.Expenses.AsNoTracking().ToList(); // Ensure List<Expense> is returned
        }

        // Add a new expense
        public bool Add(Expense expense)
        {
            try
            {
                _context.Expenses.Add(expense);
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding expense: {ex.Message}");
                return false;
            }
        }

        // Update an existing expense
        public bool Update(Expense expense)
        {
            try
            {
                _context.Expenses.Update(expense);
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating expense: {ex.Message}");
                return false;
            }
        }

        // Delete an expense by its ID
        public bool Delete(int id)
        {
            try
            {
                var expense = GetById(id);
                if (expense == null) return false;

                _context.Expenses.Remove(expense);
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting expense: {ex.Message}");
                return false;
            }
        }

        // Get recent expenses for a specific user
        public List<Expense> GetRecentExpensesByUserId(int userId)
        {
            return _context.Expenses
                .AsNoTracking()
                .Where(e => e.UserId == userId)
                .OrderByDescending(e => e.Date)
                .Take(10)
                .ToList(); // Ensure List<Expense> is returned
        }

        // Get expenses for a user within a specific date range
        public List<Expense> GetExpensesByDateRange(int userId, DateTime startDate, DateTime endDate)
        {
            return _context.Expenses
                .AsNoTracking()
                .Where(e => e.UserId == userId && e.Date >= startDate && e.Date <= endDate)
                .OrderBy(e => e.Date)
                .ToList(); // Ensure List<Expense> is returned
        }
    }
}
