// Data/IIncomeRepository.cs
using ExpenseTrackerApp.Models;
using System.Collections.Generic;

namespace ExpenseTrackerApp.Data
{
    public interface IIncomeRepository : IRepository<Income>
    {
        List<Income> GetRecentIncomesByUserId(int userId);
    }
}
