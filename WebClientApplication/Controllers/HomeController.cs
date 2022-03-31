using Data.Entites;
using Microsoft.AspNetCore.Mvc;
using Services.Catalog.Products;

namespace WebClientApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAll();
            IEnumerable<Product> productsList = products;
            return View(productsList);
        }
    }
}
