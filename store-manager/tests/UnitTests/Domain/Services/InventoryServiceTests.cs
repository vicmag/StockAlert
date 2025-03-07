using Moq;
using NUnit.Framework;
using StoreManager.Domain.Entities;
using StoreManager.Domain.Interfaces;
using StoreManager.Domain.Services;

namespace StoreManager.Tests.UnitTests.Domain.Services
{
    [TestFixture]
    public class InventoryServiceTests
    {
        private Mock<IProductRepository> _mockProductRepository;
        private IInventoryService _inventoryService;

        [SetUp]
        public void SetUp()
        {
            // Crear un mock de IProductRepository
            _mockProductRepository = new Mock<IProductRepository>();

            // Inicializar el servicio con el mock del repositorio
            _inventoryService = new InventoryService(_mockProductRepository.Object);
        }

        [Test]
        public void SetMinimumStockLevel_ShouldUpdateProductMinimumStockLevel()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Camiseta Azul", Stock = 20, MinimumStockLevel = 10 };

            // Configurar el mock para devolver el producto cuando se llame a GetById
            _mockProductRepository.Setup(repo => repo.GetById(1)).Returns(product);

            // Act
            _inventoryService.SetMinimumStockLevel(product.Id, 15);

            // Assert
            // Verificar que el método Update se llamó con el producto actualizado
            _mockProductRepository.Verify(repo => repo.Update(It.Is<Product>(p => p.MinimumStockLevel == 15)), Times.Once);
        }

        [Test]
        public void CheckLowStock_ShouldSendAlert_WhenStockIsBelowMinimum()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Camiseta Azul", Stock = 5, MinimumStockLevel = 10 };
            _mockProductRepository.Setup(repo => repo.GetById(1)).Returns(product);

            // Act
            _inventoryService.CheckLowStock(product.Id);

            // Assert
            // Verificar que se envió una alerta (esto fallará porque no está implementado)
            _mockProductRepository.Verify(repo => repo.SendAlert(It.Is<Product>(p => 
                p.Stock <= p.MinimumStockLevel
            )), Times.Once);
        }
    }
}