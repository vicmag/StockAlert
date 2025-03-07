using StoreManager.Domain.Entities;

namespace StoreManager.Domain.Interfaces
{
    public interface IProductRepository
    {
        void Add(Product product);
        Product GetById(int id);
        void Update(Product product);
        void SendAlert(Product product); // Nuevo método para enviar alertas
    }
}