namespace Store.Domain.Models
{
    public class Product
    {
        public string Id { get; }
        public string Name { get; }
        public int Stock { get; set; }
        
        public Product(string id, string name, int stock)
        {
            Id = id;
            Name = name;
            Stock = stock;
        }
    }
}
