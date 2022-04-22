namespace BANK.WEB.ViewModels.Customer
{
    public class TransactionViewModel
    {
        public decimal TransactionId { get; set; }

        public string? TransactionProtocol { get; set; }

        public string? DestinationAccount { get; set; }

        public string? RecipientName { get; set; }

        public string? Value { get; set; }

        public DateTime TransactionDate { get; set; }
    }
}
