using System;
using System.Collections.Generic;
using ExpenseTrackerApp.Data;
using ExpenseTrackerApp.Models;

namespace ExpenseTrackerApp.Controllers
{
    internal class IncomeController
    {
        private readonly IncomeRepository _incomeRepository;

        public IncomeController(ExpenseContext context)
        {
            _incomeRepository = new IncomeRepository(context);
        }

        // Add a new income
        public bool AddIncome(int userId, decimal amount, string source, DateTime date)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Income amount must be greater than zero.");
            }

            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentException("Income source cannot be empty.");
            }

            return _incomeRepository.AddIncome(userId, amount, source, date);
        }

        // Get all incomes for a user
        public List<Income> GetIncomesByUserId(int userId)
        {
            return _incomeRepository.GetIncomesByUserId(userId);
        }

        // Get recent incomes for a user
        public List<Income> GetRecentIncomesByUserId(int userId)
        {
            return _incomeRepository.GetRecentIncomesByUserId(userId);
        }

        // Update an income entry
        public bool EditIncome(int incomeId, decimal amount, string source, DateTime date)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Income amount must be greater than zero.");
            }

            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentException("Income source cannot be empty.");
            }

            return _incomeRepository.UpdateIncome(incomeId, amount, source, date);
        }

        // Delete an income
        public bool DeleteIncome(int incomeId)
        {
            return _incomeRepository.DeleteIncome(incomeId);
        }
    }
}
