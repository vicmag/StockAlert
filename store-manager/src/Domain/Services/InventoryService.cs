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
            var product = _productRepository.GetById(productId);
            if (product != null)
            {
                product.MinimumStockLevel = minimumStockLevel;
                _productRepository.Update(product);
            } 
        }
    }
}