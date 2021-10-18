using System.Security.Claims;
using System.Threading.Tasks;
using BookStore.Application.Abstractions.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;

        public AccountController(ILogger<HomeController> logger,
                                 IUserService userService)
        {
            _logger = logger;
            _userService = userService;

        }

        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }  

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Models.LoginModel login)
        {
            var user = await _userService.Login(login.UserName, login.Password).ConfigureAwait(false);
            if (user == null)
            {
                ModelState.AddModelError("", "Kullanıcı adınızı veya şifrenizi kontrol ediniz.");
                return View();
            }

            var identity = new ClaimsIdentity(new[] {
                                new Claim(ClaimTypes.Name, user.UserName),
                                new Claim(ClaimTypes.DateOfBirth, user.Birthday.ToString()),
                                new Claim(ClaimTypes.Role, "User")
                           }, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal).ConfigureAwait(false);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).ConfigureAwait(false);
            return RedirectToAction("Login");
        }
    }
}
