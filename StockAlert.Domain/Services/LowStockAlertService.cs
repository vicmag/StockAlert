using StockAlert.Domain.Repository;

namespace StockAlert.Domain.Service
{
    public class LowStockAlertService
    {
        private readonly IProductRepository _productRepository;

        public LowStockAlertService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public bool CheckLowStock(string productId)
        {
            return false;
        }
    }
}