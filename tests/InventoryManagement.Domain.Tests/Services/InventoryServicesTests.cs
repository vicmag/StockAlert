using Xunit;
using Moq;
using InventoryManagement.Domain;
using InventoryManagement.Domain.Models;
using InventoryManagement.Domain.Interfaces;
using InventoryManagement.Domain.Services;

public class InventoryServiceTests
{
    [Fact]
    public void IncrementStock_ShouldUpdateProductStockAndVerifyRepositoryCalls()
    {
        // Arrange
        var productName = "Camiseta";
        var initialStock = 10;
        var incrementAmount = 5;
        var expectedStock = initialStock + incrementAmount;
        
        var productRepoMock = new Mock<IProductRepository>();
        var testProduct = new Product { Name = productName, Stock = initialStock };
        
        productRepoMock.Setup(repo => repo.GetByName(productName))
                     .Returns(testProduct);
                     
        var inventoryService = new InventoryService(productRepoMock.Object);
        
        // Act
        inventoryService.IncrementStock(productName, incrementAmount);
        
        // Assert
        productRepoMock.Verify(repo => repo.GetByName(productName), Times.Once);
        Assert.Equal(expectedStock, testProduct.Stock);
        productRepoMock.Verify(repo => repo.Update(testProduct), Times.Once);
    }
}