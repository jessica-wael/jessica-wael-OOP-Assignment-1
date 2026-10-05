namespace ProceduralToOOP
{
    public class OrderLine
    {

        public Product Product { get; }
        public int Quantity { get; }
        public decimal UnitPrice { get; }


        public OrderLine(Product product, int quantity)
        {

            if (product == null)
                throw new ArgumentNullException(nameof(product));
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive.");
         

            Product = product;
            this.Quantity = quantity;
            UnitPrice = product.Price;


        }

        public decimal GetTotal()
        {
            return UnitPrice * Quantity;
        }



    }
}