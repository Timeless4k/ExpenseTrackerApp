// Models/Income.cs
using System;

namespace ExpenseTrackerApp.Models
{
    public class Income : Transaction
    {
        public string Source { get; set; } = string.Empty; // Non-nullable, initialized to an empty string
    }
}
