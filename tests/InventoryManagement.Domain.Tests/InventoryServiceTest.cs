using Xunit;
using Moq;

namespace InventoryService.Domain.Test.Services
{
    public class ProductServiceTests
    {
        [Fact]
        //Método_Escenario_Resultado
        public IncrementStock_WhenProductExist_ThenIncrementSctock()
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


            // Act (ejecución)
            // Assert (validación)
        }
    }
}