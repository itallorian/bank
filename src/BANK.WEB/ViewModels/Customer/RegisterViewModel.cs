namespace BANK.WEB.ViewModels.Customer
{
    public class RegisterViewModel
    {
        public string? Email { get; set; }

        public string? Name { get; set; }

        public string? Password { get; set; }

        public string? ConfirmPassword { get; set; }

        #region [ Assistant ]

        public bool ReadOnlyEmailInput
        {
            get
            {
                return string.IsNullOrEmpty(Email) == false;
            }
        }

        #endregion [ Assistant ]
    }
}
