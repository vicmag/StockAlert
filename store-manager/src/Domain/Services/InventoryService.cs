using StoreManager.Domain.Entities;
using StoreManager.Domain.Interfaces;

namespace StoreManager.Domain.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IProductRepository _productRepository;

        public InventoryService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void SetMinimumStockLevel(int productId, int minimumStockLevel)
        {
            // No implementamos la lógica aún (Fase Roja)
        }
    }
}