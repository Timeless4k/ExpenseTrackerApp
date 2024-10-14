using System;
using System.Collections.Generic;
using System.Linq;
using ExpenseTrackerApp.Models;
using ExpenseTrackerApp.Data;

namespace ExpenseTrackerApp.Controllers
{
    public class ExpenseController
    {
        private readonly ExpenseRepository _expenseRepository;

        // Constructor: Initializes the controller with the ExpenseRepository
        public ExpenseController(ExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        // Method to add a new expense
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

            _expenseRepository.AddExpense(expense);
            return true;  // Indicate success
        }

        // Method to update an existing expense
        public bool UpdateExpense(int id, string name, decimal amount, string category, DateTime date)
        {
            var updatedExpense = new Expense
            {
                Id = id,
                Name = name,
                Amount = amount,
                Category = category,
                Date = date
            };

            var success = _expenseRepository.UpdateExpense(updatedExpense);
            return success;
        }

        // Method to delete an expense
        public bool DeleteExpense(int expenseId)
        {
            var success = _expenseRepository.DeleteExpense(expenseId);
            return success;
        }

        // Method to view recent expenses for a specific user
        public void ViewRecentExpenses(int userId)
        {
            var recentExpenses = _expenseRepository.GetRecentExpensesByUserId(userId);

            if (recentExpenses.Count == 0)
            {
                Console.WriteLine("No expenses found.");
            }
            else
            {
                Console.WriteLine("Recent Expenses:");
                foreach (var expense in recentExpenses)
                {
                    Console.WriteLine($"ID: {expense.Id}, Name: {expense.Name}, Amount: {expense.Amount}, Category: {expense.Category}, Date: {expense.Date}");
                }
            }
        }

        // Method to view a specific expense by ID (optional feature)
        public void ViewExpenseById(int expenseId)
        {
            var expense = _expenseRepository.GetRecentExpensesByUserId(expenseId).FirstOrDefault();

            if (expense != null)
            {
                Console.WriteLine($"ID: {expense.Id}, Name: {expense.Name}, Amount: {expense.Amount}, Category: {expense.Category}, Date: {expense.Date}");
            }
            else
            {
                Console.WriteLine("Expense not found.");
            }
        }
    }
}
