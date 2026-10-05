namespace ProceduralToOOP
{
    public class Product
    {

        public int Id { get; }
        public string Name { get; }
        public decimal Price { get; }
        public int Stock { get; private set; }

        public Product(int id, string name, decimal price, int stock)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name is required");

            if (price <= 0)
                throw new ArgumentException("Price must be positive");
            if (stock < 0)
                throw new ArgumentException("Stock must be a non-negative number");

            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
        }
        public void ReduceStock(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive");
            if (quantity > Stock)
                throw new ArgumentException($"Not enough stock for {Name}. Available stock: {Stock}");

            Stock -= quantity;
        }
    }
}
