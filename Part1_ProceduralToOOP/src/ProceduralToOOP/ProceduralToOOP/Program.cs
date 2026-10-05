using ProceduralToOOP;

class Program
{
    static void Main()
    {
        Shop shop = new Shop();

        shop.AddCustomer(1, "Mona Ali", "mona@example.com", "Cairo", true);
        shop.AddCustomer(2, "Omar Hassan", "omar@example.com", "Alexandria", false);
        shop.AddCustomer(3, "Sara Nabil", "sara@example.com", "Giza", false);

        shop.AddProduct(101, "USB Cable", 50m, 100);
        shop.AddProduct(102, "Wireless Mouse", 250m, 40);
        shop.AddProduct(103, "Mechanical Keyboard", 1200m, 15);
        shop.AddProduct(104, "Laptop Stand", 400m, 25);

        
        shop.CreateOrder(1001, 1, new DateTime(2026, 9, 15));
        shop.AddLineToOrder(1001, 101, 2);
        shop.AddLineToOrder(1001, 102, 1);
        shop.MarkOrderPaid(1001);

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nWelcome to the Order System!");
            Console.ResetColor();
            Console.WriteLine("1. Add customer");
            Console.WriteLine("2. Add product");
            Console.WriteLine("3. List customers");
            Console.WriteLine("4. List products");
            Console.WriteLine("5. Create order");
            Console.WriteLine("6. Add line to order");
            Console.WriteLine("7. Mark order paid");
            Console.WriteLine("8. Paid sales total");
            Console.WriteLine("9. List orders");
            Console.WriteLine("0. Exit");
            Console.Write("Please select an option:");

            try
            {
               int choice = int.Parse(Console.ReadLine()!);
                switch (choice)
                {
                    case 1:
                        Console.Write("\nEnter customer id: ");
                        int custId = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter name: ");
                        string custName = Console.ReadLine()!;
                        Console.Write("Enter email: ");
                        string custEmail = Console.ReadLine()!;
                        Console.Write("Enter city: ");
                        string custCity = Console.ReadLine()!;
                        Console.Write("Is VIP? (y/n): ");
                        string vipAnswer = Console.ReadLine()!;

                        shop.AddCustomer(custId, custName, custEmail, custCity, vipAnswer.Trim().ToLower() == "y");

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Customer added.");
                        Console.ResetColor();
                        break;

                        case 2:
                        Console.Write("\nEnter product id: ");
                        int prodId = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter name: ");
                        string prodName = Console.ReadLine()!;
                        Console.Write("Enter price: ");
                        decimal prodPrice = decimal.Parse(Console.ReadLine()!);
                        Console.Write("Enter stock: ");
                        int prodStock = int.Parse(Console.ReadLine()!);

                        shop.AddProduct(prodId, prodName, prodPrice, prodStock);

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Product added.");
                        Console.ResetColor();
                        break;

                    case 3:
                        shop.PrintCustomers();
                        break;

                    case 4:
                        shop.PrintProducts();
                        break;

                    case 5:
                        Console.Write("\nEnter order id: ");
                        int orderId = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter customer id: ");
                        int orderCustId = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter date (yyyy-mm-dd): ");
                        DateTime orderDate = DateTime.Parse(Console.ReadLine()!);

                        shop.CreateOrder(orderId, orderCustId, orderDate);

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Order created.");
                        Console.ResetColor();
                       break;

                    case 6:
                        Console.Write("\nEnter order id: ");
                        int lineOrderId = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter product id: ");
                        int lineProdId = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter quantity: ");
                        int lineQuantity = int.Parse(Console.ReadLine()!);
                        shop.AddLineToOrder(lineOrderId, lineProdId, lineQuantity);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Line added to order.");
                        Console.ResetColor();
                        break;

                    case 7:
                        Console.Write("\nEnter order id: ");
                        int paidOrderId = int.Parse(Console.ReadLine()!);

                        shop.MarkOrderPaid(paidOrderId);

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Order marked as paid.");
                        Console.ResetColor();
                        break;

                    case 8:
                        decimal totalSales = shop.TotalSalesPaidOnly();
                        Console.WriteLine($"\nTotal sales (paid only): {totalSales:C}");
                        break;

                    case 9:
                        shop.PrintOrders();
                        break;

                    case 0:
                        Console.WriteLine("Exiting the system..");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;

                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Error: { ex.Message}");
                Console.ResetColor();

            }
        }
    }

   
}