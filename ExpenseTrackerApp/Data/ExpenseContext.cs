// Data/ExpenseContext.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ExpenseTrackerApp.Models;
using System.Configuration;

namespace ExpenseTrackerApp.Data
{
    public class ExpenseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Income> Income { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ExpenseTrackerDB"].ConnectionString;
            optionsBuilder.UseMySQL(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Expenses)
                .WithOne()
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Budgets)
                .WithOne()
                .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Income)  
                .WithOne()
                .HasForeignKey(i => i.UserId);
        }
    }
}
