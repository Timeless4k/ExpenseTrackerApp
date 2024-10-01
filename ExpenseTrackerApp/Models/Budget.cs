using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerApp.Models
{
    public class Budget
    {
        public int Id { get; set; }                    // Primary key
        public decimal TotalBudget { get; set; }       // Total budget amount
        public decimal RemainingBudget { get; set; }   // Remaining budget amount
        public int UserId { get; set; }                // Foreign key to the User table
        public User User { get; set; }                 // Navigation property (Optional)
    }
}

