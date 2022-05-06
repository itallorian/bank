using BANK.WEB.ViewModels.Manager;

namespace BANK.WEB.Services.Interfaces
{
    public interface IManagerService
    {
        Task Access(ManagerLoginViewModel viewModel);
    }
}
