using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using ExpenseTrackerApp.Data;
using ExpenseTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpenseTrackerApp.Tests
{
    [TestFixture]
    public class ExpenseRepositoryTests
    {
        private ExpenseContext _context = null!;
        private ExpenseRepository _repository = null!;

        [SetUp]
        public void Setup()
        {
            // Use InMemory Database for testing
            var options = new DbContextOptionsBuilder<ExpenseContext>()
                .UseInMemoryDatabase(databaseName: "ExpenseTrackerTestDb")
                .Options;

            _context = new ExpenseContext(options);
            _repository = new ExpenseRepository(_context);

            // Seed some initial data
            _context.Expenses.AddRange(
                new Expense { Id = 1, UserId = 1, Name = "Groceries", Amount = 50.00m, Category = "Food", Date = DateTime.Now },
                new Expense { Id = 2, UserId = 1, Name = "Transport", Amount = 20.00m, Category = "Transport", Date = DateTime.Now }
            );
            _context.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted(); // Clear database after each test
            _context.Dispose();
        }

        [Test]
        public void GetById_ShouldReturnExpense_WhenExpenseExists()
        {
            // Act
            var result = _repository.GetById(1);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Id, Is.EqualTo(1));
        }

        [Test]
        public void GetById_ShouldReturnNull_WhenExpenseDoesNotExist()
        {
            // Act
            var result = _repository.GetById(999); // Non-existing ID

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Add_ShouldAddExpenseSuccessfully()
        {
            // Arrange
            var newExpense = new Expense { Id = 3, UserId = 1, Name = "Rent", Amount = 500.00m, Category = "Housing", Date = DateTime.Now };

            // Act
            var result = _repository.Add(newExpense);

            // Assert
            Assert.That(result, Is.True);
            Assert.That(_context.Expenses.Count(), Is.EqualTo(3));
        }

        [Test]
        public void Update_ShouldUpdateExpenseSuccessfully()
        {
            // Arrange
            var existingExpense = _context.Expenses.First();
            existingExpense.Amount = 100.00m;

            // Act
            var result = _repository.Update(existingExpense);

            // Assert
            Assert.That(result, Is.True);
            Assert.That(_context.Expenses.First().Amount, Is.EqualTo(100.00m));
        }

        [Test]
        public void Delete_ShouldRemoveExpense_WhenExpenseExists()
        {
            // Act
            var result = _repository.Delete(1);

            // Assert
            Assert.That(result, Is.True);
            Assert.That(_context.Expenses.Count(), Is.EqualTo(1)); // One item should be removed
        }

        [Test]
        public void GetRecentExpensesByUserId_ShouldReturnExpensesForUser()
        {
            // Act
            var result = _repository.GetRecentExpensesByUserId(1);

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result.All(e => e.UserId == 1), Is.True);
        }

        [Test]
        public void GetExpensesByDateRange_ShouldReturnExpensesWithinDateRange()
        {
            // Arrange
            var startDate = DateTime.Now.AddDays(-1);
            var endDate = DateTime.Now.AddDays(1);

            // Act
            var result = _repository.GetExpensesByDateRange(1, startDate, endDate);

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result.All(e => e.Date >= startDate && e.Date <= endDate), Is.True);
        }
    }
}
