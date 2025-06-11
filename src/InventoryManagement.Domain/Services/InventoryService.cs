using InventoryManagement.Domain.Interfaces;
using InventoryManagement.Domain.Models;
using InventoryManagement.Domain.Exceptions;

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
            var product = _productRepository.GetByName(productName);
            if (product == null)
            {
                throw new ProductNotFoundException($"Product '{productName}' not found.");
            }
            return product;
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