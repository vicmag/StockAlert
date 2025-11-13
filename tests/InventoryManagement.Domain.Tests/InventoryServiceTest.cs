using System.Threading.Tasks;
using Moq;
using Xunit;
using InventoryManagement.Domain.Interfaces;
using InventoryManagement.Domain.Models;
using InventoryManagement.Domain.Services;
using InventoryManagement.Domain.Exceptions;

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
        public async Task IncreaseStock_ShouldReturnError_WhenProductNotFound()
        {
            // Arrange
            var productName = "ProductoInexistente";
            var incrementAmount = 5;
            
            // Mock del repositorio que retorna null (producto no encontrado)
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(repo => repo.FindByName(productName))
                .ReturnsAsync((Product)null); // Simula que no encuentra el producto
                    
            // El método Save nunca debería llamarse
            mockRepo.Setup(repo => repo.Save(It.IsAny<Product>()))
                .Verifiable(); // Para verificación posterior
                
            var service = new ProductService(mockRepo.Object);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ProductNotFoundException>(() =>
                service.IncreaseStock(productName, incrementAmount));
            
            // Assert
            Assert.Contains("no encontrado", exception.Message);
            Assert.Contains(productName, exception.Message);
            
            // Verificar que Save nunca fue llamado
            mockRepo.Verify(repo => repo.Save(It.IsAny<Product>()), Times.Never);
        }
    }
}