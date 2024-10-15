using NUnit.Framework;
using System;
using Moq;
using ExpenseTrackerApp.Controllers;
using ExpenseTrackerApp.Data;
using ExpenseTrackerApp.Models;

namespace ExpenseTrackerApp.Tests
{
    [TestFixture]
    public class ExpenseControllerTests
    {
        private ExpenseController _expenseController = null!;
        private Mock<IExpenseRepository> _mockExpenseRepository = null!;

        [SetUp]
        public void Setup()
        {
            // Initialize the mock repository and controller
            _mockExpenseRepository = new Mock<IExpenseRepository>();
            _expenseController = new ExpenseController(_mockExpenseRepository.Object);
        }

        [Test]
        public void AddExpense_ShouldAddExpenseSuccessfully()
        {
            // Arrange
            var userId = 1;
            var name = "Groceries";
            var amount = 50.00m;
            var category = "Food";
            var date = DateTime.Now;

            _mockExpenseRepository.Setup(repo => repo.Add(It.IsAny<Expense>())).Returns(true);

            // Act
            var result = _expenseController.AddExpense(userId, name, amount, category, date);

            // Assert
            Assert.That(result, Is.True);
            _mockExpenseRepository.Verify(repo => repo.Add(It.IsAny<Expense>()), Times.Once);
        }

        [Test]
        public void UpdateExpense_ShouldUpdateExpenseSuccessfully()
        {
            // Arrange
            var existingExpense = new Expense
            {
                Id = 1,
                Name = "Dinner",
                Amount = 100.00m,
                Category = "Food",
                Date = DateTime.Now,
                UserId = 1
            };

            _mockExpenseRepository.Setup(repo => repo.GetById(1)).Returns(existingExpense);
            _mockExpenseRepository.Setup(repo => repo.Update(It.IsAny<Expense>())).Returns(true);

            // Act
            var result = _expenseController.UpdateExpense(1, "Lunch", 120.00m, "Food", DateTime.Now);

            // Assert
            Assert.That(result, Is.True);
            _mockExpenseRepository.Verify(repo => repo.GetById(1), Times.Once);
            _mockExpenseRepository.Verify(repo => repo.Update(It.IsAny<Expense>()), Times.Once);
        }

        [Test]
        public void DeleteExpense_ShouldCallDeleteOnRepository()
        {
            // Arrange
            var expenseId = 1;
            _mockExpenseRepository.Setup(repo => repo.Delete(expenseId)).Returns(true);

            // Act
            var result = _expenseController.DeleteExpense(expenseId);

            // Assert
            Assert.That(result, Is.True);
            _mockExpenseRepository.Verify(repo => repo.Delete(expenseId), Times.Once);
        }

        [Test]
        public void DeleteExpense_ShouldReturnFalse_WhenExpenseDoesNotExist()
        {
            // Arrange
            var expenseId = 999; // Non-existing ID
            _mockExpenseRepository.Setup(repo => repo.Delete(expenseId)).Returns(false);

            // Act
            var result = _expenseController.DeleteExpense(expenseId);

            // Assert
            Assert.That(result, Is.False);
        }
    }
}
