using Store.Domain.Models;

namespace Store.Domain.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;
        
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
        public void IncreaseStock(string productId, int increment)
        {
            var product = GetProduct(productId);
            UpdateStock(product, increment);
            SaveChanges(product);
        }

        private Product GetProduct(string productId)
        {
            return _productRepository.GetById(productId);
        }

        private void UpdateStock(Product product, int increment)
        {
            product.Stock += increment;
        }

        private void SaveChanges(Product product)
        {
            _productRepository.Save(product);
        }
    }
}