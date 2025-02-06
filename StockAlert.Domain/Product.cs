namespace StockAlert.Domain
{
    public class Product
    {
        public string Id { get; }
        public string Name { get; }
        public int CurrentStock { get; }
        public int LowStockThreshold { get; }

        public Product(string id, string name, int currentStock, int lowStockThreshold)
        {
            Id = id;
            Name = name;
            CurrentStock = currentStock;
            LowStockThreshold = lowStockThreshold;
        }
    }
}