using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerApp.Models
{
    public class Expense
    {
        public int Id { get; set; }               // Primary key
        public string Name { get; set; }          // Name of the expense
        public decimal Amount { get; set; }       // Expense amount
        public string Category { get; set; }      // Expense category (e.g., Food, Transport)
        public DateTime Date { get; set; }        // Date of the expense
        public int? UserId { get; set; }          // Foreign key to the User table
        public User User { get; set; }            // Navigation property (Optional)
    }
}

