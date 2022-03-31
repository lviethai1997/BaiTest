using Microsoft.AspNetCore.Mvc;

namespace AdminApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var session = HttpContext.Session.GetString("SessionUser");
            if (session == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}