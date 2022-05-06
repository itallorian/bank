namespace BANK.BUSINESSLOGIC.Models.User
{
    public class User
    {
        public decimal? Id { get; set; }

        public bool Active { get; set; }

        public string? Name { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; }

        public string? Email { get; set; }

        public List<Customer.Customer>? Customers { get; set; }
    }
}
