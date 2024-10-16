using System;
using System.Collections.Generic;
using System.Linq;
using ExpenseTrackerApp.Models;

namespace ExpenseTrackerApp.Data
{
    public class IncomeRepository : IIncomeRepository
    {
        private readonly ExpenseContext _context;

        // Constructor with context initialization
        public IncomeRepository(ExpenseContext context)
        {
            _context = context;
        }

        public Income? GetById(int id)
        {
            return _context.Income.Find(id);
        }

        public List<Income> GetAll()
        {
            return _context.Income.ToList();
        }

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
            return _context.Income.Where(i => i.UserId == userId).OrderByDescending(i => i.Date).Take(10).ToList();
        }

        public List<Income> GetIncomesByDateRange(int userId, DateTime startDate, DateTime endDate)
        {
            return _context.Income
                .Where(i => i.UserId == userId && i.Date >= startDate && i.Date <= endDate)
                .ToList();
        }
    }
}
