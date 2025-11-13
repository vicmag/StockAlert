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
            var product = await FindProductByNameAsync(productName);
            
            ApplyStockChange(product, amount);
            
            await PersistChangesAsync(product);
        }

        // findProductByName busca un producto por nombre en el repositorio
        private async Task<Product> FindProductByNameAsync(string name)
        {
            return await _productRepository.FindByName(name);
        }

        // applyStockChange aplica el incremento al stock del producto
        private void ApplyStockChange(Product product, int amount)
        {
            product.Stock += amount;
        }

        // persistChanges guarda los cambios en el repositorio
        private async Task PersistChangesAsync(Product product)
        {
            await _productRepository.Save(product);
        }
    }
}