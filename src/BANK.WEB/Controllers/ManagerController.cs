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
    }
}
