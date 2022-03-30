using Microsoft.AspNetCore.Mvc;

namespace AdminApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
