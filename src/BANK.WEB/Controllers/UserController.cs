using BANK.WEB.Services.Interfaces;
using BANK.WEB.ViewModels.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BANK.WEB.Controllers
{
    [Authorize(AuthenticationSchemes = "User")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpGet, Route("~/user")]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated && User.Identity.AuthenticationType.Equals("User"))
            {
                return RedirectToAction(nameof(CustomerApproval));
            }

            return View(new UserLoginViewModel());
        }

        [AllowAnonymous]
        [HttpPost, Route("~/user")]
        public async Task<IActionResult> Login([FromForm] UserLoginViewModel viewModel)
        {
            await _userService.Access(viewModel);

            if (viewModel.HasAccess == false)
            {
                viewModel.Message = "Incorrect username or password";

                return View(viewModel);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, viewModel.UserId.ToString()),
                new Claim(ClaimTypes.Sid, viewModel.UserName),
                new Claim(ClaimTypes.Role, "User")
            };

            var claimsIdentity = new ClaimsIdentity(claims, "User");

            var authProperties = new AuthenticationProperties();

            await HttpContext.SignInAsync("User", new ClaimsPrincipal(claimsIdentity), authProperties);

            return RedirectToAction(nameof(CustomerApproval));
        }

        [HttpGet, Route("~/user/customer/approval")]
        public async Task<IActionResult> CustomerApproval()
        {
            var viewModel = await _userService.UsersCustomerApproval(Convert.ToDecimal(User.Identity.Name));

            return View(viewModel);
        }

        [HttpGet, Route("~/user/customer/approval/{id}")]
        public async Task<IActionResult> CustomerApproval([FromRoute(Name = "id")] string customerId)
        {
            await _userService.ApproveUser(Convert.ToDecimal(customerId), Convert.ToDecimal(User.Identity.Name));

            return Redirect("/user/customer/approval");
        }
    }
}
