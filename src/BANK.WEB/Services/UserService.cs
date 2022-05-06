using BANK.BUSINESSLOGIC.Models.User;
using BANK.REPOSITORY.Repositories.Interfaces;
using BANK.WEB.Services.Interfaces;
using BANK.WEB.ViewModels.User;

namespace BANK.WEB.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICustomerRepository _customerRepository;

        public UserService(IUserRepository userRepository, ICustomerRepository customerRepository)
        {
            _userRepository = userRepository;
            _customerRepository = customerRepository;
        }

        public async Task Access(UserLoginViewModel viewModel)
        {
            User? user = _userRepository.GetUser(viewModel.UserName, viewModel.Password);

            if (user != null)
            {
                viewModel.HasAccess = true;
            }

            await Task.CompletedTask;
        }

    }
}
