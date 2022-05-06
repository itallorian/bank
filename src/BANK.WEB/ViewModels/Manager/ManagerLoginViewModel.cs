namespace BANK.WEB.ViewModels.Manager
{
    public class ManagerLoginViewModel
    {
        public string? UserName { get; set; }

        public string? Password { get; set; }

        public bool HasAccess { get; set; }

        public string? Message { get; set; }
    }
}
