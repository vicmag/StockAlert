using Xunit;
using Moq;
using Store.Domain;
using Store.Domain.Models;
using Store.Domain.Services;

public class ProductServiceTests
{
    [Fact]
    public void IncreaseStock_ShouldIncrementExistingProductStock()
    {
        // Arrange
        var productId = "prod-001";
        var initialStock = 10;
        var incrementAmount = 5;
        
        var productRepoMock = new Mock<IProductRepository>();
        var testProduct = new Product(productId, "Camiseta", initialStock);
        productRepoMock.Setup(repo => repo.GetById(productId))
                      .Returns(testProduct);
        productRepoMock.Setup(repo => repo.Save(testProduct))
                      .Verifiable();
                      
        var productService = new ProductService(productRepoMock.Object);
        
        // Act
        productService.IncreaseStock(productId, incrementAmount);
        
        // Assert
        productRepoMock.Verify(repo => repo.GetById(productId), Times.Once);
        Assert.Equal(initialStock + incrementAmount, testProduct.Stock);
        productRepoMock.Verify(repo => repo.Save(testProduct), Times.Once);
    }
}
