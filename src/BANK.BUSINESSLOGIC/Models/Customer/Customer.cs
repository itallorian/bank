namespace BANK.BUSINESSLOGIC.Models.Customer
{
    public class Customer
    {
        public decimal Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public DateTime InsertionDate { get; set; }

        public bool Okay { get; set; }

        public decimal? UserApproval { get; set; }

        public Account? Account { get; set; }
    }
}
