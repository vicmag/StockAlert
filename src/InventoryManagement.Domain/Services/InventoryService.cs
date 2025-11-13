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
            // 1. Buscar el producto por nombre
            var product = await _productRepository.FindByName(productName);
            
            // 2. Incrementar el stock con la cantidad especificada
            product.Stock += amount;
            
            // 3. Guardar los cambios
            await _productRepository.Save(product);
        }
    }
}