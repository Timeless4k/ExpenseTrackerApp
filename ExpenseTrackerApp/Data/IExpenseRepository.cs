using ExpenseTrackerApp.Models;
using System;
using System.Collections.Generic;

namespace ExpenseTrackerApp.Data
{
    public interface IExpenseRepository : IRepository<Expense>
    {
        // Fetch recent expenses for a specific user
        List<Expense> GetRecentExpensesByUserId(int userId);

        // Fetch expenses for a specific user within a given date range
        List<Expense> GetExpensesByDateRange(int userId, DateTime startDate, DateTime endDate);
    }
}
