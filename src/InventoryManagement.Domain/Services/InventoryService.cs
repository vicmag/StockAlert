using InventoryManagement.Domain.Interfaces;
using InventoryManagement.Domain.Models;

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
            var product = GetProduct(productName);
            IncreaseStock(product, incrementAmount);
            SaveProduct(product);
        }
    
        private Product GetProduct(string productName)
        {
            return _productRepository.GetByName(productName);
        }

        private void IncreaseStock(Product product, int incrementAmount)
        {
            product.Stock += incrementAmount;
        }

        private void SaveProduct(Product product)
        {
            _productRepository.Update(product);
        }

    }
}