namespace StoreManager.Domain.Interfaces
{
    public interface IInventoryService
    {
        void SetMinimumStockLevel(int productId, int minimumStockLevel);

        public void CheckLowStock(int productId);
    }
}
 