using System.Collections.Generic;

namespace ExpenseTrackerApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        // Navigation properties
        public ICollection<Expense> Expenses { get; set; }
        public ICollection<Budget> Budgets { get; set; }   // One or more budgets
        public ICollection<Income> Incomes { get; set; }   // Multiple sources of income
    }
}
