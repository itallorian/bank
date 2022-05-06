using BANK.WEB.ViewModels.Manager;

namespace BANK.WEB.Services.Interfaces
{
    public interface IManagerService
    {
        Task Access(ManagerLoginViewModel viewModel);

        Task<List<ManagerUserViewModel>> GetUsers();

        Task CreateUser(ManagerUserViewModel viewModel);
    }
}
