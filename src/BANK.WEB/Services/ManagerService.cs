﻿using BANK.BUSINESSLOGIC.Models.Manager;
using BANK.BUSINESSLOGIC.Models.User;
using BANK.REPOSITORY.Repositories.Interfaces;
using BANK.WEB.Services.Interfaces;
using BANK.WEB.ViewModels.Manager;

namespace BANK.WEB.Services
{
    public class ManagerService : IManagerService
    {
        private readonly IManagerRepository _managerRepository;
        private readonly IUserRepository _userRepository;

        public ManagerService(IManagerRepository managerRepository, IUserRepository userRepository)
        {
            _managerRepository = managerRepository;
            _userRepository = userRepository;
        }

        public async Task Access(ManagerLoginViewModel viewModel)
        {
            Manager? manager = _managerRepository.GetManager(viewModel.UserName, viewModel.Password);

            if (manager != null)
            {
                viewModel.HasAccess = true;
            }

            await Task.CompletedTask;
        }

        public async Task<List<ManagerUserViewModel>> GetUsers()
        {
            var viewModel = new List<ManagerUserViewModel>();

            List<User> users = _userRepository.GetUsers();

            foreach (User user in users)
            {
                viewModel.Add(new ManagerUserViewModel()
                {
                    UserId = user.Id,
                    Active = user.Active,
                    Name = user.Name,
                    UserName = user.UserName,
                    Email = user.Email,
                });
            }

            await Task.CompletedTask;

            return viewModel;
        }


        public async Task CreateUser(ManagerUserViewModel viewModel)
        {
            #region [ Validate Entry ]

            bool userExists = _userRepository.CheckUserExistence(viewModel.UserName, viewModel.Email);

            if (userExists == true)
            {
                viewModel.Message = "User already exist.";
                return;
            }

            #endregion [ Validate Entry ]

            User user = new User()
            {
                Name = viewModel.Name,
                UserName = viewModel.UserName,
                Email = viewModel.Email,
                Password = viewModel.Password
            };

            decimal userId = _userRepository.AddUser(user);

            if (userId > 0)
            {
                viewModel.Success = true;
                return;
            }

            viewModel.Message = "Error adding user, please try again.";
        }
    }
}
