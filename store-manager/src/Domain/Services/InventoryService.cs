using StoreManager.Domain.Entities;
using StoreManager.Domain.Interfaces;

namespace StoreManager.Domain.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IProductRepository _productRepository;

        public InventoryService(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public void SetMinimumStockLevel(int productId, int minimumStockLevel)
        {
            if (minimumStockLevel <= 0)
                throw new ArgumentException("El nivel mínimo de stock debe ser mayor que cero.", nameof(minimumStockLevel));

            var product = _productRepository.GetById(productId);
            if (product == null)
                throw new InvalidOperationException($"No se encontró el producto con ID {productId}.");

            product.MinimumStockLevel = minimumStockLevel;
            _productRepository.Update(product);
        }
    }
}