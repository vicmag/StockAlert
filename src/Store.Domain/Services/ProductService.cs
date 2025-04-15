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
            throw new System.NotImplementedException();
        }
    }
}
throw new System.NotImplementedException();