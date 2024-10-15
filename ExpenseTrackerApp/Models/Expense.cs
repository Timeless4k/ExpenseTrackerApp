// Models/Expense.cs
using System;

namespace ExpenseTrackerApp.Models
{
    public class Expense : Transaction
    {
        public string Name { get; set; } = string.Empty; // Non-nullable, initialized to an empty string
        public string Category { get; set; } = string.Empty; // Non-nullable, initialized to an empty string
    }
}
