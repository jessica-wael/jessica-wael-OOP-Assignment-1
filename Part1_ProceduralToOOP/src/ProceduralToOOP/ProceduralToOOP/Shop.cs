namespace ProceduralToOOP;

public class Shop
{
    private readonly List<Customer> _customers = new List<Customer>();
    private readonly List<Product> _products = new List<Product>();
    private readonly List<Order> _orders = new List<Order>();

    public void AddCustomer(int id, string name, string email, string city, bool isVip)
    {
        if (FindCustomer(id) != null)
            throw new InvalidOperationException("Customer id already exists.");
        _customers.Add(new Customer(id, name, email, city, isVip));
    }

    public void AddProduct(int id, string name, decimal price, int stock)
    {
        if (FindProduct(id) != null)
            throw new InvalidOperationException("Product id already exists.");
        _products.Add(new Product(id, name, price, stock));
    }

    public void CreateOrder(int orderId, int customerId, DateTime date)
    {
        if (FindOrder(orderId) != null)
            throw new InvalidOperationException("Order id already exists.");

        Customer? customer = FindCustomer(customerId);
        if (customer == null)
            throw new InvalidOperationException("Customer not found.");

        _orders.Add(new Order(orderId, customer, date ));
    }

    public void AddLineToOrder(int orderId, int productId, int quantity)
    {
        Order? order = FindOrder(orderId);
        if (order == null)
            throw new InvalidOperationException("Order not found.");

        Product? product = FindProduct(productId);
        if (product == null)
            throw new InvalidOperationException("Product not found.");

        order.AddLine(product, quantity);
    }

    public void MarkOrderPaid(int orderId)
    {
        Order? order = FindOrder(orderId);
        if (order == null)
            throw new InvalidOperationException("Order not found.");

        order.MarkPaid();
    }

    public decimal TotalSalesPaidOnly()
    {
        decimal total = 0;
        foreach (Order order in _orders)
        {
            if (order.IsPaid)
            {
                total = total + order.GetTotal();
            }
        }
        return total;
    }

    public void PrintCustomers()
    {
        foreach (Customer c in _customers)
        {
            string vip = c.IsVip ? " (VIP)" : "";
            Console.WriteLine($"Customer {c.Id}:  , {c.Name} | '{c.Email}' | {c.City} , {vip}");
        }
    }

    public void PrintProducts()
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("Products:");
        Console.ResetColor();
        foreach (Product p in _products)
        {
            Console.WriteLine($"Product {p.Id}: , {p.Name} | {p.Price} | stock {p.Stock}");
        }
    }

    public void PrintOrders()
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("Orders:");
        Console.ResetColor();
        foreach (Order o in _orders)
        {
            o.Print();
        }
    }

    private Customer? FindCustomer(int id)
    {
        foreach (Customer c in _customers)
        {
            if (c.Id == id) return c;
        }
        return null;
    }

    private Product? FindProduct(int id)
    {
        foreach (Product p in _products)
        {
            if (p.Id == id) return p;
        }
        return null;
    }

    private Order? FindOrder(int id)
    {
        foreach (Order o in _orders)
        {
            if (o.Id == id) return o;
        }
        return null;
    }
}