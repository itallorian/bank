using BANK.BUSINESSLOGIC.Models.Manager;
using BANK.REPOSITORY.Repositories.Interfaces;
using BANK.WEB.Services.Interfaces;
using BANK.WEB.ViewModels.Manager;

namespace BANK.WEB.Services
{
    public class ManagerService : IManagerService
    {
        private readonly IManagerRepository _managerRepository;

        public ManagerService(IManagerRepository managerRepository)
        {
            _managerRepository = managerRepository;
        }

        public async Task Access(ManagerLoginViewModel viewModel)
        {
            Manager? manager = _managerRepository.GetManager(viewModel.UserName, viewModel.Password);

            if (manager != null)
            {
                viewModel.HasAccess = true;
            }
        }
    }
}
