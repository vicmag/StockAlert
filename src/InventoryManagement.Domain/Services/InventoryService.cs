using System.Threading.Tasks;
using InventoryManagement.Domain.Interfaces;
using InventoryManagement.Domain.Models;
using InventoryManagement.Domain.Exceptions;

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
            
            // 2. Si el producto no existe, lanzar excepción
            if (product == null)
            {
                throw new ProductNotFoundException($"Producto '{productName}' no encontrado");
            }
            
            // 3. Solo incrementar y guardar si el producto existe
            product.Stock += amount;
            
            // 4. Guardar los cambios
            await _productRepository.Save(product);
        }

        
    }
}