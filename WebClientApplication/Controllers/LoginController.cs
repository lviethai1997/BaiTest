using Microsoft.AspNetCore.Mvc;
using Services.Catalog.Users;
using ViewModels.Catalog.Login;

namespace WebClientApplication.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        public const string UserKey = "SessionUser";
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            var login = await _userService.Login(request);

            if (login == false)
            {
                ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng");
                return View("Index");
            }

            HttpContext.Session.SetString(UserKey, request.Username);

            return RedirectToAction("Index", "Home");
        }
    }
}
