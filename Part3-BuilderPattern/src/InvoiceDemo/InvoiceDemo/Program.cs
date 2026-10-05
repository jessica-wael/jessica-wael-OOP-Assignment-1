
using InvoiceDemo;
using System;
public class Program
{
        public static void Main(string[] args)
        {

           var invoice = new Invoice.InvoiceBuilder("INV-1001", "Ali Hassan", "ali@gmail.com")
            .WithPhone("+20 100 000 0000")
            .WithBillingAddress("1 Nile St", "Cairo", "Cairo", "11511", "EG")
            .OrderedOn(new DateTime(2026, 10, 5))
            .PaidBy("Card")
            .InCurrency("EGP")
            .WithSubTotal(1000m)
            .WithDiscount(100m)
            .WithTax(126m)
            .Build();

            Console.WriteLine(invoice.InvoiceId);      
            Console.WriteLine(invoice.TotalAmount);    
            Console.WriteLine(invoice.ShippingCity);   
        }

}
