using System;
using System.Collections.Generic;
using System.Linq;
using ExpenseTrackerApp.Models;
using ExpenseTrackerApp.Data;

namespace ExpenseTrackerApp.Data
{
    public class IncomeRepository
    {
        private readonly ExpenseContext _context;

        public IncomeRepository(ExpenseContext context)
        {
            _context = context;
        }

        // Method to Add Income
        public bool AddIncome(int userId, decimal amount, string source, DateTime date)
        {
            if (amount <= 0 || string.IsNullOrEmpty(source))
            {
                return false; // Validation: amount should be positive and source cannot be empty
            }

            var income = new Income
            {
                UserId = userId,
                Amount = amount,
                Source = source,
                Date = date
            };

            _context.Income.Add(income);
            _context.SaveChanges();
            return true;
        }

        // Method to Get Incomes by User ID
        public List<Income> GetIncomesByUserId(int userId)
        {
            return _context.Income.Where(i => i.UserId == userId).ToList() ?? new List<Income>();
        }

        // Method to Get Recent Incomes by User ID
        public List<Income> GetRecentIncomesByUserId(int userId)
        {
            return _context.Income
                           .Where(i => i.UserId == userId)
                           .OrderByDescending(i => i.Date)
                           .Take(5)  // Get the last 5 recent incomes
                           .ToList();
        }

        // Method to Get Income by Income ID
        public Income GetIncomeById(int incomeId)
        {
            return _context.Income.SingleOrDefault(i => i.Id == incomeId);
        }

        // Method to Update Income (using parameters)
        public bool UpdateIncome(int incomeId, decimal amount, string source, DateTime date)
        {
            var income = _context.Income.SingleOrDefault(i => i.Id == incomeId);
            if (income == null)
            {
                return false; // Income not found
            }

            income.Amount = amount;
            income.Source = source;
            income.Date = date;

            _context.SaveChanges();
            return true;
        }

        // Overloaded Method to Update Income with Income Object
        public bool UpdateIncome(Income updatedIncome)
        {
            var income = _context.Income.SingleOrDefault(i => i.Id == updatedIncome.Id);
            if (income == null)
            {
                return false; // Income not found
            }

            income.Amount = updatedIncome.Amount;
            income.Source = updatedIncome.Source;
            income.Date = updatedIncome.Date;

            _context.SaveChanges();
            return true;
        }

        // Method to Delete Income
        public bool DeleteIncome(int incomeId)
        {
            var income = _context.Income.SingleOrDefault(i => i.Id == incomeId);
            if (income == null)
            {
                return false; // Income not found
            }

            _context.Income.Remove(income);
            _context.SaveChanges();
            return true;
        }
    }
}
