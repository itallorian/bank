﻿using BANK.WEB.ViewModels.User;

namespace BANK.WEB.Services.Interfaces
{
    public interface IUserService
    {
        Task Access(UserLoginViewModel viewModel);

        Task<List<UserCustomerApprovalViewModel>> UsersCustomerApproval(decimal userId);

        Task ApproveUser(decimal customerId, decimal userId);
    }
}