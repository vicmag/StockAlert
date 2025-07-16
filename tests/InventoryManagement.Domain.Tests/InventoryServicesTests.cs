using InventoryManagement.Domain.Models;
using InventoryManagement.Domain.Interfaces;
using InventoryManagement.Domain.Services;
using InventoryManagement.Domain.Exceptions;
using Xunit;
using Moq;

namespace InventoryManagement.Domain.Tests
{
    public class InventoryServicesTests{
        [Fact]        
        public void IncrementStock_CuandoIncrementoStock_EntoncesSeAlmacenaCorrectamente()
        {
            // Arrange (configuración)
            var productName = "Camiseta";
            var initialStock = 10;
            var incrementAmount = 5;
            var expectedStock = initialStock + incrementAmount;

            var testProduct = new Product {
                Name = productName,
                Stock = initialStock
            };

            var repositoryMock = new Mock<IProductRepository>();

            repositoryMock.Setup(repo => repo.FindByName(productName))
                .Returns(testProduct);

            var inventoryService = new InventoryService(repositoryMock.Object);
        
            // Act (ejecución)
            inventoryService.IncrementStock(productName, incrementAmount);

            // Assert (validación)
            repositoryMock.Verify(repo => repo.FindByName(productName), Times.Once);
            Assert.Equal(expectedStock, testProduct.Stock);
            repositoryMock.Verify(repo => repo.Update(testProduct), Times.Once);

        }

        [Fact]
        public void IncrementStock_CuandoArticuloInexistente_EntoncesSeLanzaExcepcion()
        {
            // Arrange (configuración)
            var productName = "ProductoInexistente";
            var incrementAmount = 5;

            var repositoryMock = new Mock<IProductRepository>();
            var inventoryService = new InventoryService(repositoryMock.Object);

            repositoryMock.Setup(repo => repo.FindByName(productName))
                .Returns((Product)null);

            // Act & Assert (ejecución & validación)
            Assert.Throws<ProductNotFoundException>(() =>
                inventoryService.IncrementStock(productName, incrementAmount));
            repositoryMock.Verify(repo => repo.Update(It.IsAny<Product>()), Times.Never);
        }

    }

    
}
