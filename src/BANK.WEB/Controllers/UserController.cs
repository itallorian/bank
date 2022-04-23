using BANK.WEB.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace BANK.WEB.Controllers
{
    public class UserController : Controller
    {
        [HttpGet, Route("~/user")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, Route("~/user")]
        public IActionResult Login([FromForm] UserLoginViewModel viewModel)
        {
            return View(viewModel);
        }

        [HttpGet, Route("~/user/customer/approval")]
        public IActionResult CustomerApproval()
        {
            List<UserCustomerApprovalViewModel> viewModel = new List<UserCustomerApprovalViewModel>();

            viewModel.Add(new UserCustomerApprovalViewModel()
            {
                Name = "teste",
                Email = "teste",
                DateRegister = DateTime.Now
            });

            return View(viewModel);
        }

        [HttpGet, Route("~/user/customer/approval/{id}")]
        public IActionResult CustomerApproval([FromRoute(Name = "id")] string customerId)
        {
            List<UserCustomerApprovalViewModel> viewModel = new List<UserCustomerApprovalViewModel>();

            viewModel.Add(new UserCustomerApprovalViewModel()
            {
                Name = "teste",
                Email = "teste",
                DateRegister = DateTime.Now
            });

            return View(viewModel);
        }
    }
}
