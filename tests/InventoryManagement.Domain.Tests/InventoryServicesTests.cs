using InventoryManagement.Domain.Models;
using InventoryManagement.Domain.Interfaces;
using InventoryManagement.Domain.Services;
using InventoryManagement.Domain.Exceptions;
using Xunit;
using Moq;

namespace InventoryManagement.Domain.Tests
{
    public class InventoryServiceTests
    {
        [Fact]
        public void IncrementStock_ShouldUpdateProductStockAndVerifyRepositoryCalls()
        {
            // Arrange (configuración)
            var productName = "Camiseta";
            var initialStock = 10;
            var incrementAmount = 5;
            var expectedStock = initialStock + incrementAmount;

            var productRepoMock = new Mock<IProductRepository>();
            var testProduct = new Product { Name = productName, Stock = initialStock };

            productRepoMock.Setup(repo => repo.FindByName(productName))
                .Returns(testProduct);

            var inventoryService = new InventoryService(productRepoMock.Object);

            // Act (Ejecución)
            inventoryService.IncrementStock(productName, incrementAmount);

            // Assert (Validación)
            productRepoMock.Verify(repo => repo.FindByName(productName), Times.Once);
            Assert.Equal(expectedStock, testProduct.Stock);
            productRepoMock.Verify(repo => repo.Update(testProduct), Times.Once);

        }

        [Fact]
        public void IncrementStock_DebeMandarExcepcion_CuandoElProductoNoExiste()
        {
            // Arrange (configuración)
            var productName = "ProductoInexistente";
            var incrementAmount = 5;
            
            var productRepoMock = new Mock<IProductRepository>();
            
            productRepoMock.Setup(repo => repo.FindByName(productName))
                .Returns((Product)null);

            productRepoMock.Setup(repo => repo.Update(It.IsAny<Product>()))
                .Verifiable();

            var inventoryService = new InventoryService(productRepoMock.Object);

            // Act & Assert (Ejecución & Validación)
            Assert.Throws<ProductNotFoundException>(() =>
                inventoryService.IncrementStock(productName, incrementAmount));

            productRepoMock.Verify(repo => repo.FindByName(productName), Times.Once);
            productRepoMock.Verify(repo => repo.Update(It.IsAny<Product>()), Times.Never);

        }

    }
}