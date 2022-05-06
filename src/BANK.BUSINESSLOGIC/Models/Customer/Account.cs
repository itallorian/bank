namespace BANK.BUSINESSLOGIC.Models.Customer
{
    public class Account
    {
        public string? AccountNumber { get; set; }

        public string? Balance { get; set; }

        public List<Transaction>? Transactions { get; set; }
    }
}
