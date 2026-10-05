
namespace ProceduralToOOP
{
    public class Order
    {
        private readonly List<OrderLine> _lines = new List<OrderLine>();
        public int Id { get; }
        public Customer Customer { get; }
        public DateTime OrderDate { get; }
        public bool IsPaid { get; private set; }

        public IReadOnlyList<OrderLine> Lines => _lines;

        public Order(int id, Customer customer, DateTime orderDate)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            Id = id;
            Customer = customer;
            OrderDate = orderDate;
            IsPaid = false;

        }


        public void AddLine(Product product, int quantity)
        {
            if (IsPaid)
                throw new InvalidOperationException("Order is already paid");

            OrderLine line = new OrderLine(product, quantity );
            product.ReduceStock(quantity);
            _lines.Add(line);
        }

        public void MarkPaid()
        {
            if (IsPaid)
                throw new InvalidOperationException("Order is already paid");

            if (_lines.Count == 0)
                throw new InvalidOperationException("Can't pay an empty order");

            IsPaid = true;

        }


        public decimal GetSubTotal()
        {
            decimal total = 0;
            foreach (OrderLine line in _lines)
            {
                total += line.GetTotal();
            }
            return total;
        }
        public decimal GetTotal()
        {
            return GetSubTotal() * (1 - Customer.DiscountRate);
        }
        public void Print()
        {
            string status = IsPaid ? "PAID" : "UNPAID";
            Console.WriteLine($"Order {Id} | {Customer.Name} | {OrderDate:yyyy-MM-dd} | {status}");
            foreach (OrderLine line in _lines)
            {
                Console.WriteLine($"{line.Product.Name} x{line.Quantity}   {line.UnitPrice} = {line.GetTotal()}");
            }
            Console.WriteLine($"Subtotal: {GetSubTotal()} | Total: {GetTotal()}");
        }

    }
}