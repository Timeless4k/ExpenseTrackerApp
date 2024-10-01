using Microsoft.EntityFrameworkCore;                      // For Entity Framework Core
using Microsoft.Extensions.Configuration;                // For configuration handling
using ExpenseTrackerApp.Models;                          // For referencing your models
using System.Configuration;                              // For accessing the App.config connection string

namespace ExpenseTrackerApp.Data
{
    public class ExpenseContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Budget> Budgets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Fetch connection string from App.config
            var connectionString = ConfigurationManager.ConnectionStrings["ExpenseTrackerDB"].ConnectionString;

            // Use MySQL from the new package for Entity Framework Core
            optionsBuilder.UseMySQL(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define relationships between User, Expense, and Budget models
            modelBuilder.Entity<User>()
                .HasMany(u => u.Expenses)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Budgets)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId);
        }
    }
}
