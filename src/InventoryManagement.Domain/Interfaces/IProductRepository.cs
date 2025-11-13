using System.Threading.Tasks;
using InventoryManagement.Domain.Models;

namespace InventoryManagement.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> FindByName(string name);
        Task Save(Product product);
    }
}