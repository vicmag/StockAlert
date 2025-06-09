namespace InventoryManagement.Domain.Tests.Services
{
    public class InventoryServiceTests
    {
        [Fact]
        public void IncrementStock_CuandoIncrementoElStockDeUnProducto_EntoncesSeAlmacenaCorrectamente()
        {
            //Arrange (configuración)
            var productName = "Camiseta";
            var initialStock = 10;
            var incrementStock = 5;

            var productRepositoryMock = new Mock<IProductRepository>(); 

            //Act (ejecución)
            //Assert (verificación)

        }
    }
}