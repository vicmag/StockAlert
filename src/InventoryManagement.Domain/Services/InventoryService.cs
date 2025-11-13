using System;
using System.Threading.Tasks;
using InventoryManagement.Domain.Interfaces;
using InventoryManagement.Domain.Models;

namespace InventoryManagement.Domain.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task IncreaseStock(string productName, int amount)
        {
            // Implementación vacía para fase roja
            throw new NotImplementedException();
        }
    }
}