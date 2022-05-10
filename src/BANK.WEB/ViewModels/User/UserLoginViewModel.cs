namespace BANK.WEB.ViewModels.User
{
    public class UserLoginViewModel
    {
        public string? UserName { get; set; }

        public string? Password { get; set; }

        public bool HasAccess { get; set; }

        public decimal? UserId { get; set; }

        public string? Message { get; set; }
    }
}
