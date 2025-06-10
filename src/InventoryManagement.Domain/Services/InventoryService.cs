using InventoryManagement.Domain.Interfaces;

namespace InventoryManagement.Domain.Services
{
    public class InventoryService
    {
        private readonly IProductRepository _productRepository;

        public InventoryService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void IncrementStock(string productName, int incrementAmount)
        {
            //No hay implementación. Fase Roja
            throw new NotImplementedException("Sin implementación. Fase Roja.");
        }

    }
}