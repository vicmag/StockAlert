using System;
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
            //Fase Refactorización
            var product = _productRepository.FindByName(productName);
            IncrementProductStock(product, incrementAmount);
            _productRepository.Update(product);

        }

        private void IncrementProductStock(Product product, int increment){
            product.Stock += increment;
        }
    }
}