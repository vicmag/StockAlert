using InventoryManagement.Domain.Models;

namespace InventoryManagement.Domain.Interfaces
{
    public interface IProductRepository
    {
        Product FindByName(string productName);
        void Update(Product product);
    }
}