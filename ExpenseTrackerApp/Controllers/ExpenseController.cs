using ExpenseTrackerApp.Models;
using ExpenseTrackerApp.Data;
using System;
using System.Collections.Generic;

namespace ExpenseTrackerApp.Controllers
{
    public class ExpenseController
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseController(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        // Add a new expense
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

        // Update an existing expense by its ID
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

        // Delete an expense by its ID
        public bool DeleteExpense(int expenseId)
        {
            return _expenseRepository.Delete(expenseId);
        }

        // Get an expense by its ID
        public Expense? GetExpenseById(int expenseId)
        {
            return _expenseRepository.GetById(expenseId);
        }

        // Get all expenses for a specific user
        public List<Expense> GetExpensesByUserId(int userId)
        {
            return _expenseRepository.GetRecentExpensesByUserId(userId);
        }

        // Get expenses within a specific date range
        public List<Expense> GetExpensesByDateRange(int userId, DateTime startDate, DateTime endDate)
        {
            return _expenseRepository.GetExpensesByDateRange(userId, startDate, endDate);
        }

        // Get all expenses (general use)
        public List<Expense> GetAllExpenses()
        {
            return _expenseRepository.GetAll();
        }
    }
}
