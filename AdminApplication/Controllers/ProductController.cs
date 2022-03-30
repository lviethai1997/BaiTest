using Microsoft.AspNetCore.Mvc;
using Services.Catalog.ProductCategories;
using Services.Catalog.Products;
using ViewModels.Catalog.ProductCategories;
using ViewModels.Catalog.Products;

namespace AdminApplication.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;

        public ProductController(IProductService productService, IProductCategoryService productCategoryService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAll();

            if (TempData["result"] != null)
            {
                ViewBag.message = TempData["result"];
            }
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var Category = _productCategoryService.getCategory();
            List<CbCategories> cate = await Category;
            ViewBag.category = cate;


            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] ProductRequest request)
        {
            var Category = _productCategoryService.getCategory();
            List<CbCategories> cate = await Category;
            ViewBag.category = cate;

            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var result = await _productService.CreateProduct(request);
            if (result == true)
            {
                TempData["result"] = "Success";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["result"] = "Failed";
                return View(request);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var getById = await _productService.GetById(id);
            var Category = _productCategoryService.getCategory();

            List<CbCategories> cate = await Category;
            ViewBag.category = cate;
            return View(getById);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductRequest request)
        {
            var Category = _productCategoryService.getCategory();
            List<CbCategories> cate = await Category;
            ViewBag.category = cate;

            if (!ModelState.IsValid)
            {
                return View();
            }


            if (request.Image == null)
            {
                return View();
            }

            var result = await _productService.UpdateProduct(id, request);
            if (result == true)
            {
                TempData["result"] = "Success";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["result"] = "Failed";
                return View(request);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var getById = await _productService.GetById(id);
            return View(getById);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, IFormCollection collections)
        {
            var result = await _productService.DeleteProduct(id);
            if (result == true)
            {
                TempData["result"] = "Success";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["result"] = "Failed";
                return View();
            }
        }

        [HttpGet]
        public async Task<ActionResult> Hide(int id)
        {
            var result = await _productService.HideProduct(id);

            if (result == true)
            {
                TempData["result"] = "Success";
                return RedirectToAction("Index");
            }

            TempData["result"] = "Failed";
            return RedirectToAction("Index");
        }
    }
}