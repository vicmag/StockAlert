using System.Threading.Tasks;
using Xunit;
using Moq;
using InventoryManagement.Domain.Models;
using InventoryManagement.Domain.Interfaces;
using InventoryManagement.Domain.Services;

namespace InventoryService.Domain.Test.Services
{
    public class ProductServiceTests
    {
        [Fact]
        //Método_Escenario_Resultado
        public async Task IncrementStock_WhenProductExist_ThenIncrementStock()
        {
            // Arrange (configuración)
            var productName = "Camiseta";
            var initialStock = 10;
            var increment = 5;

            var product = new Product
            {
                Name = productName,
                Stock = initialStock
            };

            var mockDB = new Mock<IProductRepository>();

            //Configurar el comportamientos de los métodos de BD (mocks)
            //(stubs)
            mockDB.Setup(repo => repo.FindByName(productName))
                .ReturnsAsync(product);

            mockDB.Setup(repo => repo.Save(It.Is<Product>(p =>
                p.Stock == (initialStock+increment))))
                .Returns(Task.CompletedTask);

            var service = new ProductService(mockDB.Object);
            
            // Act (ejecución)
            await service.IncrementStock(productName,increment);

            // Assert (validación)
            mockDB.Verify(repo => repo.FindByName(productName), Times.Once);
            mockDB.Verify(repo => repo.Save(It.Is<Product>(product =>
                product.Stock == (initialStock+increment))), Times.Once);

        }
    }
}