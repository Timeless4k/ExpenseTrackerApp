using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using ExpenseTrackerApp.Models;
using ExpenseTrackerApp.Data;

namespace ExpenseTrackerApp.Tests
{
    [TestFixture]
    public class IncomeRepositoryTests
    {
        private IncomeRepository _incomeRepository = null!;
        private ExpenseContext _context = null!;

        [SetUp]
        public void Setup()
        {
            // Use InMemory Database for testing
            var options = new DbContextOptionsBuilder<ExpenseContext>()
                .UseInMemoryDatabase(databaseName: "ExpenseTrackerTestDb")
                .Options;

            _context = new ExpenseContext(options);
            _incomeRepository = new IncomeRepository(_context);

            // Seed some initial data
            _context.Income.AddRange(
                new Income { Id = 1, UserId = 1, Source = "Salary", Amount = 1000.00m, Date = DateTime.Now.AddDays(-10) },
                new Income { Id = 2, UserId = 1, Source = "Freelance", Amount = 500.00m, Date = DateTime.Now.AddDays(-5) }
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
        public void GetById_ShouldReturnIncome_WhenIncomeExists()
        {
            // Act
            var result = _incomeRepository.GetById(1);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Id, Is.EqualTo(1));
        }

        [Test]
        public void GetById_ShouldReturnNull_WhenIncomeDoesNotExist()
        {
            // Act
            var result = _incomeRepository.GetById(999); // Non-existing ID

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Add_ShouldAddIncomeSuccessfully()
        {
            // Arrange
            var newIncome = new Income { Id = 3, UserId = 1, Source = "Bonus", Amount = 200.00m, Date = DateTime.Now };

            // Act
            var result = _incomeRepository.Add(newIncome);

            // Assert
            Assert.That(result, Is.True);
            Assert.That(_context.Income.Count(), Is.EqualTo(3));
        }

        [Test]
        public void Update_ShouldUpdateIncomeSuccessfully()
        {
            // Arrange
            var existingIncome = _context.Income.First();
            existingIncome.Amount = 1500.00m;

            // Act
            var result = _incomeRepository.Update(existingIncome);

            // Assert
            Assert.That(result, Is.True);
            Assert.That(_context.Income.First().Amount, Is.EqualTo(1500.00m));
        }

        [Test]
        public void Delete_ShouldRemoveIncome_WhenIncomeExists()
        {
            // Act
            var result = _incomeRepository.Delete(1);

            // Assert
            Assert.That(result, Is.True);
            Assert.That(_context.Income.Count(), Is.EqualTo(1)); // One item should be removed
        }

        [Test]
        public void Delete_ShouldReturnFalse_WhenIncomeDoesNotExist()
        {
            // Act
            var result = _incomeRepository.Delete(999); // Non-existing ID

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void GetRecentIncomesByUserId_ShouldReturnIncomesForUser()
        {
            // Act
            var result = _incomeRepository.GetRecentIncomesByUserId(1);

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result.All(i => i.UserId == 1), Is.True);
        }

        [Test]
        public void GetIncomesByDateRange_ShouldReturnIncomesWithinDateRange()
        {
            // Arrange
            var startDate = DateTime.Now.AddDays(-15);
            var endDate = DateTime.Now.AddDays(-1);

            // Act
            var result = _incomeRepository.GetIncomesByDateRange(1, startDate, endDate);

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result.All(i => i.Date >= startDate && i.Date <= endDate), Is.True);
        }
    }
}
