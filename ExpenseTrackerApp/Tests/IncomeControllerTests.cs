using NUnit.Framework;
using Moq;
using System;
using ExpenseTrackerApp.Controllers;
using ExpenseTrackerApp.Data;
using ExpenseTrackerApp.Models;

namespace ExpenseTrackerApp.Tests
{
    [TestFixture]
    public class IncomeControllerTests
    {
        private IncomeController _incomeController = null!;
        private Mock<IIncomeRepository> _mockIncomeRepository = null!;

        [SetUp]
        public void Setup()
        {
            // Initialize the mock repository and controller
            _mockIncomeRepository = new Mock<IIncomeRepository>();
            _incomeController = new IncomeController(_mockIncomeRepository.Object);
        }

        [Test]
        public void AddIncome_ShouldAddIncomeSuccessfully()
        {
            // Arrange
            var userId = 1;
            var amount = 1000.00m;
            var source = "Salary";
            var date = DateTime.Now;

            _mockIncomeRepository.Setup(repo => repo.Add(It.IsAny<Income>())).Returns(true);

            // Act
            var result = _incomeController.AddIncome(userId, amount, source, date);

            // Assert
            Assert.That(result, Is.True);
            _mockIncomeRepository.Verify(repo => repo.Add(It.IsAny<Income>()), Times.Once);
        }

        [Test]
        public void AddIncome_ShouldReturnFalse_WhenIncomeIsNotAdded()
        {
            // Arrange
            var userId = 1;
            var amount = 1000.00m;
            var source = "Salary";
            var date = DateTime.Now;

            _mockIncomeRepository.Setup(repo => repo.Add(It.IsAny<Income>())).Returns(false);

            // Act
            var result = _incomeController.AddIncome(userId, amount, source, date);

            // Assert
            Assert.That(result, Is.False);
            _mockIncomeRepository.Verify(repo => repo.Add(It.IsAny<Income>()), Times.Once);
        }

        [Test]
        public void UpdateIncome_ShouldUpdateIncomeSuccessfully()
        {
            // Arrange
            var existingIncome = new Income
            {
                Id = 1,
                Amount = 1000.00m,
                Source = "Salary",
                Date = DateTime.Now,
                UserId = 1
            };

            _mockIncomeRepository.Setup(repo => repo.GetById(1)).Returns(existingIncome);
            _mockIncomeRepository.Setup(repo => repo.Update(It.IsAny<Income>())).Returns(true);

            // Act
            var result = _incomeController.UpdateIncome(1, 1200.00m, "Bonus", DateTime.Now);

            // Assert
            Assert.That(result, Is.True);
            _mockIncomeRepository.Verify(repo => repo.GetById(1), Times.Once);
            _mockIncomeRepository.Verify(repo => repo.Update(It.IsAny<Income>()), Times.Once);
        }

        [Test]
        public void UpdateIncome_ShouldReturnFalse_WhenIncomeDoesNotExist()
        {
            // Arrange
            // Use nullable type here to avoid the warning
            _mockIncomeRepository.Setup(repo => repo.GetById(999)).Returns((Income?)null);

            // Act
            var result = _incomeController.UpdateIncome(999, 1200.00m, "Bonus", DateTime.Now);

            // Assert
            Assert.That(result, Is.False);
            _mockIncomeRepository.Verify(repo => repo.GetById(999), Times.Once);
            _mockIncomeRepository.Verify(repo => repo.Update(It.IsAny<Income>()), Times.Never);
        }

        [Test]
        public void UpdateIncome_ShouldReturnFalse_WhenUpdateFails()
        {
            // Arrange
            var existingIncome = new Income
            {
                Id = 1,
                Amount = 1000.00m,
                Source = "Salary",
                Date = DateTime.Now,
                UserId = 1
            };

            _mockIncomeRepository.Setup(repo => repo.GetById(1)).Returns(existingIncome);
            _mockIncomeRepository.Setup(repo => repo.Update(It.IsAny<Income>())).Returns(false);

            // Act
            var result = _incomeController.UpdateIncome(1, 1200.00m, "Bonus", DateTime.Now);

            // Assert
            Assert.That(result, Is.False);
            _mockIncomeRepository.Verify(repo => repo.GetById(1), Times.Once);
            _mockIncomeRepository.Verify(repo => repo.Update(It.IsAny<Income>()), Times.Once);
        }

        [Test]
        public void DeleteIncome_ShouldReturnTrue_WhenIncomeIsDeletedSuccessfully()
        {
            // Arrange
            var incomeId = 1;
            _mockIncomeRepository.Setup(repo => repo.Delete(incomeId)).Returns(true);

            // Act
            var result = _incomeController.DeleteIncome(incomeId);

            // Assert
            Assert.That(result, Is.True);
            _mockIncomeRepository.Verify(repo => repo.Delete(incomeId), Times.Once);
        }

        [Test]
        public void DeleteIncome_ShouldReturnFalse_WhenIncomeIsNotDeleted()
        {
            // Arrange
            var incomeId = 999;
            _mockIncomeRepository.Setup(repo => repo.Delete(incomeId)).Returns(false);

            // Act
            var result = _incomeController.DeleteIncome(incomeId);

            // Assert
            Assert.That(result, Is.False);
            _mockIncomeRepository.Verify(repo => repo.Delete(incomeId), Times.Once);
        }
    }
}
