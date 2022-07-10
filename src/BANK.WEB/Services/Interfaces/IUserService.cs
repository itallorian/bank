using BANK.WEB.ViewModels.User;

namespace BANK.WEB.Services.Interfaces
{
    public interface IUserService
    {
        Task Access(UserLoginViewModel viewModel);

        Task<List<UserCustomerViewModel>> UsersCustomerApproval();

        Task<List<UserCustomerViewModel>> UserCustomers(decimal userId);

        Task ApproveUser(decimal customerId, decimal userId);
    }
}
