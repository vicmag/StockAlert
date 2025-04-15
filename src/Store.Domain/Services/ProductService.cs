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
            // 1. Obtener el producto
            var product = _productRepository.GetById(productId);
            
            // 2. Incrementar el stock
            product.Stock += increment;
            
            // 3. Guardar los cambios
            _productRepository.Save(product);
        }
    }
}
