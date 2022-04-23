using BANK.WEB.ViewModels.Manager;
using Microsoft.AspNetCore.Mvc;

namespace BANK.WEB.Controllers
{
    public class ManagerController : Controller
    {
        [HttpGet, Route("~/management")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, Route("~/management")]
        public IActionResult Login([FromForm] ManagerLoginViewModel viewModel)
        {
            return View(viewModel);
        }

        [HttpGet, Route("~/management/user/list")]
        public IActionResult UserList()
        {
            List<ManagerUserViewModel> viewModel = new List<ManagerUserViewModel>();
            viewModel.Add(new ManagerUserViewModel()
            {
                UserId = 1,
                UserName = "UserName",
                Active = true,
                Email = "Email",
                Name = "Name"
            });

            return View(viewModel);
        }

        [HttpGet, Route("~/management/user/new")]
        public IActionResult UserCreate()
        {
            return View();
        }

        [HttpPost, Route("~/management/user/new")]
        public IActionResult UserCreate([FromForm] ManagerUserViewModel viewModel)
        {
            return View(viewModel);
        }

        [HttpGet, Route("~/management/user/edit/{id}")]
        public IActionResult UserEdit([FromRoute(Name = "id")] string userId)
        {
            return View();
        }

        [HttpPost, Route("~/management/user/edit/{id}")]
        public IActionResult UserEdit([FromForm] ManagerUserViewModel viewModel)
        {
            return View(viewModel);
        }
    }
}
