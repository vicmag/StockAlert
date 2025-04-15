using Store.Domain.Models; 

namespace Store.Domain
{
    public interface IProductRepository
    {
        Product GetById(string productId);
        void Save(Product product);
    }
}
