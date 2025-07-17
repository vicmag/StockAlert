using System;
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
            //Nuevo ciclo RGR. Pruebas de valores límite
            if (incrementAmount<=0)
            {
                throw new ArgumentException("El incremento debe ser positivo.");
            }
            var product = GetProduct(productName);
            IncrementProductStock(product, incrementAmount);
            UpdateProduct(product);
        }

        private Product GetProduct(string productName){
            var product = _productRepository.FindByName(productName);
            if (product == null){
                throw new ProductNotFoundException("El producto no existe.");
            }
            return product;
        }

        private void IncrementProductStock(Product product, int increment){
            product.Stock += increment;
        }

        private void UpdateProduct(Product product){
            _productRepository.Update(product);
        }
    }
}