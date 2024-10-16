// Transaction.cs
using System;

namespace ExpenseTrackerApp.Models
{
    public abstract class Transaction
    {
        public int Id { get; set; }
        public decimal? Amount { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; } 
    }
}
