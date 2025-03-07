namespace StoreManager.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public int MinimumStockLevel { get; set; }
    }
}