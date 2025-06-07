using InventoryManagement.Domain.Models;

namespace InventoryManagement.Domain.Interfaces
{
    public interface IProductRepository
    {
        Product GetByName(string productName);
        void Update(Product product);
    }
}