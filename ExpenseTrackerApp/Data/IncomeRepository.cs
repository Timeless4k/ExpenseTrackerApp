// Data/IncomeRepository.cs
using System.Collections.Generic;
using System.Linq;
using ExpenseTrackerApp.Models;

namespace ExpenseTrackerApp.Data
{
    public class IncomeRepository : IIncomeRepository
    {
        private readonly ExpenseContext _context;

        // Use expression-bodied constructor
        public IncomeRepository(ExpenseContext context) => _context = context;

        public Income? GetById(int id) => _context.Income.Find(id);

        public List<Income> GetAll() => _context.Income.ToList();

        public bool Add(Income income)
        {
            _context.Income.Add(income);
            return _context.SaveChanges() > 0;
        }

        public bool Update(Income income)
        {
            _context.Income.Update(income);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var income = GetById(id);
            if (income == null) return false;
            _context.Income.Remove(income);
            return _context.SaveChanges() > 0;
        }

        public List<Income> GetRecentIncomesByUserId(int userId)
        {
            return _context.Income.Where(i => i.UserId == userId).ToList();
        }

        // Additional methods if needed, like getting income by specific criteria, etc.
        public List<Income> GetIncomesByDateRange(int userId, DateTime startDate, DateTime endDate)
        {
            return _context.Income
                .Where(i => i.UserId == userId && i.Date >= startDate && i.Date <= endDate)
                .ToList();
        }
    }
}
