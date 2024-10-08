﻿using System;
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

            _context.Income.Add(income);  // Corrected to match the table name 'Income'
            _context.SaveChanges();
            return true;
        }

        // Method to Get Incomes by User ID
        public List<Income> GetIncomesByUserId(int userId)
        {
            var incomes = _context.Income.Where(i => i.UserId == userId).ToList();

            // If no incomes are found, return an empty list
            if (incomes == null || incomes.Count == 0)
            {
                return new List<Income>(); // Return empty list if no incomes are found
            }

            return incomes;
        }

        // Method to Get Recent Incomes by User ID (limit to recent 5 or custom limit)
        public List<Income> GetRecentIncomesByUserId(int userId, int limit = 5)
        {
            var incomes = _context.Income
                                  .Where(i => i.UserId == userId)
                                  .OrderByDescending(i => i.Date)
                                  .Take(limit)
                                  .ToList();

            // If no incomes are found, return an empty list
            if (incomes == null || incomes.Count == 0)
            {
                return new List<Income>(); // Return empty list if no incomes are found
            }

            return incomes;
        }

        // Method to Update Income
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
