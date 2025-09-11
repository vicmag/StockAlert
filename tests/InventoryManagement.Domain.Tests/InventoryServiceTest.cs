using InventoryManagement.Domain.Models;
using InventoryManagement.Domain.Interfaces;
using InventoryManagement.Domain.Services;

using Xunit;
using Moq;

namespace InventoryManagement.Domain.Tests
{
    public class InventoryServiceTest
    {
        [Fact]
        public void IncrementStock_ShouldUpdateProduct()
        {
            //Arrange (configuración)
            var productName = "Camiseta";
            var initialStock = 10;
            var increment = 5;
            var finalStock = initialStock + increment;

            var testProduct = new Product { Name = productName, Stock = initialStock };
            var mockRepository = new Mock<IProductRepository>();

            //Definición del comportamiento de los mock (stub)
            mockRepository.Setup(repo => repo.FindByName(productName))
                .Returns(testProduct);

            var inventoryService = new InventoryService(mockRepository.Object);

            //Act (ejecución)
            inventoryService.IncrementStock(productName, increment);

            //Assert (validación)
            mockRepository.Verify(repo => repo.FindByName(productName), Times.Once);
            Assert.Equal(finalStock, testProduct.Stock);
            mockRepository.Verify(repo => repo.Update(testProduct), Times.Once);

        }
    }
}