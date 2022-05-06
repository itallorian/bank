namespace BANK.BUSINESSLOGIC.Models.User
{
    public class User
    {
        public string? UserName { get; set; }

        public string? Password { get; set; }

        public List<Customer.Customer>? Customers { get; set; }
    }
}
