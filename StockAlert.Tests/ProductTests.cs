using NUnit.Framework;
using Moq;
using StockAlert.Domain;
using StockAlert.Domain.Repository;
using StockAlert.Domain.Service;

namespace StockAlert.Tests.Domain
{
    [TestFixture]
    public class LowStockAlertServiceTests
    {
        [Test]
        public void CheckLowStock_WhenStockIsLow_ReturnsTrue()
        {
            // Arrange
            var product = new Product("1", "Product A", 5, 10); // Stock bajo
            var mockRepository = new Mock<IProductRepository>();
            mockRepository.Setup(repo => repo.FindById("1")).Returns(product);

            var service = new LowStockAlertService(mockRepository.Object);

            // Act
            var isLowStock = service.CheckLowStock("1");

            // Assert
            Assert.That(isLowStock, Is.EqualTo(true));
        }
    }
}