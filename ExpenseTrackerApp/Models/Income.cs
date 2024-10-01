using System;

namespace ExpenseTrackerApp.Models
{
    public class Income
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Source { get; set; } // e.g., Salary, Bonus, Gift
        public DateTime Date { get; set; }

        // Foreign key to User
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
