using NUnit.Framework;
using StoreManager.Domain.Entities;
using StoreManager.Domain.Interfaces;
using StoreManager.Domain.Services;

namespace StoreManager.Tests.UnitTests.Domain.Services
{
    [TestFixture]
    public class InventoryServiceTests
    {
        private IInventoryService _inventoryService;
        private IProductRepository _productRepository;

        [SetUp]
        public void SetUp()
        {
            _productRepository = new MockProductRepository();
            _inventoryService = new InventoryService(_productRepository);
        }

        [Test]
        public void SetMinimumStockLevel_ShouldUpdateProductMinimumStockLevel()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Camiseta Azul", Stock = 20, MinimumStockLevel = 10 };
            _productRepository.Add(product);

            // Act
            _inventoryService.SetMinimumStockLevel(product.Id, 15);

            // Assert
            var updatedProduct = _productRepository.GetById(product.Id);
            Assert.That(updatedProduct.MinimumStockLevel, Is.EqualTo(15));
        }
    }
}