using NUnit.Framework;
using StockAlert.Domain;

namespace StockAlert.Tests
{
    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void IsLowInStock_StockBelowThreshold_ReturnsTrue()
        {
            // Arrange
            var product = new Product("1", "Test Product", 3, 5);

            // Act
            var result = product.IsLowInStock();

            // Assert
            Assert.IsTrue(result);
        }
    }
}