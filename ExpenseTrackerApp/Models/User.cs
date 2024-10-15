// Models/User.cs
using System.Collections.Generic;

namespace ExpenseTrackerApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // Add the PasswordHash property
        public string PasswordHash { get; set; } = string.Empty;

        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
        public ICollection<Budget> Budgets { get; set; } = new List<Budget>();
        public ICollection<Income> Income { get; set; } = new List<Income>();
    }
}
