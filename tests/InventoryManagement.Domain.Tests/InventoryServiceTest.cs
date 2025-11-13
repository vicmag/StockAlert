using System.Threading.Tasks;
using Moq;
using Xunit;
using InventoryManagement.Domain.Interfaces;
using InventoryManagement.Domain.Models;
using InventoryManagement.Domain.Services;

namespace InventoryManagement.Domain.Tests.Services
{
    public class ProductServiceTests
    {
        [Fact]
        public async Task IncreaseStock_ShouldIncrementProductStock_WhenProductExists()
        {
            // Arrange
            var productName = "Camiseta";
            var initialStock = 10;
            var incrementAmount = 5;
            
            var mockProduct = new Product 
            { 
                Name = productName, 
                Stock = initialStock 
            };
            
            var mockRepo = new Mock<IProductRepository>();
            
            // Configuración del comportamiento esperado
            mockRepo.Setup(repo => repo.FindByName(productName))
                .ReturnsAsync(mockProduct);
                
            mockRepo.Setup(repo => repo.Save(It.Is<Product>(p => 
                p.Stock == (initialStock + incrementAmount))))
                .Returns(Task.CompletedTask);
            
            var service = new ProductService(mockRepo.Object);

            // Act
            await service.IncreaseStock(productName, incrementAmount);

            // Assert
            mockRepo.Verify(repo => repo.FindByName(productName), Times.Once);
            mockRepo.Verify(repo => repo.Save(It.Is<Product>(p => 
                p.Stock == (initialStock + incrementAmount))), Times.Once);
        }
        
        [Fact]
        public void IncreaseStock_ShouldThrowException_WhenProductDoesNotExist()
        {
            // Este test se implementará en la siguiente iteración
            // Por implementar en la siguiente iteración
        }
    }
}