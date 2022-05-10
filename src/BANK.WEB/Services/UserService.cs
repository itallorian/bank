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
                viewModel.UserId = user.Id;
            }

            await Task.CompletedTask;
        }

        public async Task<List<UserCustomerApprovalViewModel>> UsersCustomerApproval(decimal userId)
        {
            var viewModel = new List<UserCustomerApprovalViewModel>();

            var customersToApprove = _customerRepository.GetCustomersToApprove();

            foreach (var customer in customersToApprove)
            {
                viewModel.Add(new UserCustomerApprovalViewModel()
                {
                    CustomerId = customer.Id,
                    Name = customer.Name,
                    Email = customer.Email,
                    DateRegister = customer.InsertionDate
                });
            }

            await Task.CompletedTask;

            return viewModel;
        }

        public async Task ApproveUser(decimal customerId, decimal userId)
        {
            _customerRepository.ApproveUser(customerId, userId);

            await Task.CompletedTask;
        }
    }
}
