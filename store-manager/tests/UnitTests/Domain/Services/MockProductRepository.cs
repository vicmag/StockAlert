using System.Collections.Generic;
using System.Linq;
using StoreManager.Domain.Entities;
using StoreManager.Domain.Interfaces;

namespace StoreManager.Tests.UnitTests.Domain.Services
{
    public class MockProductRepository : IProductRepository
    {
        private List<Product> _products = new List<Product>(); // Especifica el tipo genérico

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Stock = product.Stock;
                existingProduct.MinimumStockLevel = product.MinimumStockLevel;
            }
        }
    }
}