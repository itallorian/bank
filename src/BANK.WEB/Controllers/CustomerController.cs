using BANK.WEB.ViewModels.Customer;
using Microsoft.AspNetCore.Mvc;

namespace BANK.WEB.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet, Route("~/register")]
        public IActionResult Register([FromQuery(Name = "e")] string email)
        {
            RegisterViewModel viewModel = new RegisterViewModel()
            {
                Email = email
            };

            return View(viewModel);
        }

        [HttpPost, Route("~/register")]
        public IActionResult Register([FromForm] RegisterViewModel viewModel)
        {
            return View(viewModel);
        }

        [HttpGet, Route("~/login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, Route("~/login")]
        public IActionResult Login([FromForm] LoginViewModel viewModel)
        {
            return View();
        }
        
        [HttpGet, Route("~/customer/me")]
        public IActionResult Edit()
        {
            EditViewModel viewModel = new EditViewModel()
            {

            };

            return View(viewModel);
        }
    }
}
