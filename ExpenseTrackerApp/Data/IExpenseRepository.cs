// Data/IExpenseRepository.cs
using ExpenseTrackerApp.Models;
using System.Collections.Generic;

namespace ExpenseTrackerApp.Data
{
    public interface IExpenseRepository : IRepository<Expense>
    {
        List<Expense> GetRecentExpensesByUserId(int userId);
    }
}
