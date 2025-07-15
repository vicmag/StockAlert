using System;
using InventoryManagement.Domain.Interfaces;

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
            //Fase Verde
            var product = _productRepository.FindByName(productName);
            product.Stock += incrementAmount;
            _productRepository.Update(product);

        }
    }
}