namespace BANK.WEB.ViewModels.Manager
{
    public class ManagerUserViewModel
    {
        public decimal? UserId { get; set; }

        public bool Active { get; set; }

        public string? Name { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        #region [ Assistant ]

        public string ActiveText
        {
            get
            {
                return Active == true ? "Yes" : "No";
            }
        }

        #endregion [ Assistant ]
    }
}
