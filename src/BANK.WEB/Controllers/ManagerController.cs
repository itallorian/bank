using BANK.WEB.Services.Interfaces;
using BANK.WEB.ViewModels.Manager;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BANK.WEB.Controllers
{
    [Authorize(AuthenticationSchemes = "Manager")]
    public class ManagerController : Controller
    {
        private readonly IManagerService _managerService;

        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        [AllowAnonymous]
        [HttpGet, Route("~/management")]
        public IActionResult Login([FromQuery(Name = "ReturnUrl")] string returnUrl)
        {
            if (User.Identity.IsAuthenticated && User.Identity.AuthenticationType.Equals("Manager"))
            {
                return RedirectToAction(nameof(UserList));
            }

            TempData["ReturnUrl"] = returnUrl;

            return View(new ManagerLoginViewModel());
        }

        [AllowAnonymous]
        [HttpPost, Route("~/management")]
        public async Task<IActionResult> Login([FromForm] ManagerLoginViewModel viewModel)
        {
            await _managerService.Access(viewModel);

            if (viewModel.HasAccess == false)
            {
                viewModel.Message = "Incorrect username or password";

                return View(viewModel);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, viewModel.UserName),
                new Claim(ClaimTypes.Role, "Manager"),
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Manager");

            var authProperties = new AuthenticationProperties();

            await HttpContext.SignInAsync("Manager", new ClaimsPrincipal(claimsIdentity), authProperties);

            if (TempData["ReturnUrl"] != null && string.IsNullOrEmpty(TempData["ReturnUrl"].ToString()) == false)
            {
                string url = TempData["ReturnUrl"].ToString();
                TempData["ReturnUrl"] = null;

                return Redirect(url);
            }

            return RedirectToAction(nameof(UserList));
        }

        [HttpGet, Route("~/management/user/list")]
        public async Task<IActionResult> UserList()
        {
            List<ManagerUserViewModel> viewModel = await _managerService.GetUsers();

            return View(viewModel);
        }

        [HttpGet, Route("~/management/user/new")]
        public IActionResult UserCreate()
        {
            return View(new ManagerUserViewModel());
        }

        [HttpPost, Route("~/management/user/new")]
        public async Task<IActionResult> UserCreate([FromForm] ManagerUserViewModel viewModel)
        {
            await _managerService.CreateUser(viewModel);

            if (viewModel.Success == true)
            {
                return RedirectToAction(nameof(UserList));
            }

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

        [HttpGet, Route("management/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("Manager");

            return RedirectToAction(nameof(Login));
        }
    }
}
