namespace BANK.WEB.ViewModels.Customer
{
    public class BalanceViewModel
    {
        public string? AccountNumber { get; set; }

        public string? Balance { get; set; }

        public List<TransactionViewModel>? Transactions { get; set; }
    }
}
