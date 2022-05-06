namespace BANK.BUSINESSLOGIC.Models.Customer
{
    public class Transaction
    {
        public decimal TransactionId { get; set; }

        public string? TransactionProtocol { get; set; }

        public string? DestinationAccount { get; set; }

        public string? RecipientName { get; set; }

        public string? Value { get; set; }

        public DateTime? TransactionDate { get; set; }

        public decimal? TransferValue { get; set; }

        public string? LimitValue { get; set; }
    }
}
