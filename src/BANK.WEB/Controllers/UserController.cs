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
    }
}
