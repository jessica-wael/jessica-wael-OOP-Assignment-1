namespace ProceduralToOOP
{
    public class Customer
    {

        public int Id { get; }
        public string Name { get; }
        public string Email { get; }
        public string City { get; }
        public bool IsVip { get; }

        public Customer(int id, string name, string email, string city, bool isVip)
        {
            if (string.IsNullOrEmpty(name))
                throw (new ArgumentException("Name can't be empty"));

            if (string.IsNullOrEmpty(email))
                throw (new ArgumentException("Email can't be empty"));

            Id = id;
            Name = name;
            Email = email;
            City = city;
            IsVip = isVip;
        }

        public decimal DiscountRate => IsVip ? 0.10m : 0m;


    }
}