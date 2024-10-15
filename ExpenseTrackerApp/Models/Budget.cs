// Models/Budget.cs
using System;

namespace ExpenseTrackerApp.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public decimal TotalBudget { get; set; }  // Add this property
        public decimal RemainingBudget { get; set; }  // Add this property
        public string Name { get; set; } = string.Empty;  // Non-nullable, initialized
        public int UserId { get; set; }
    }
}
