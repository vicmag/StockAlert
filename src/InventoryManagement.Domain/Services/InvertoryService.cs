using System;
using System.Threading.Tasks;
using InventoryManagement.Domain.Interfaces;

namespace InventoryManagement.Domain.Services
{
    public class ProductService
    {   
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task IncrementStock(string productName,int increment)
        {
            throw new NotImplementedException();
        }


    }
}