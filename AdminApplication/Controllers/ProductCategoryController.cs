using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Catalog.ProductCategories;
using ViewModels.Catalog.ProductCategories;

namespace AdminApplication.Controllers
{
    public class ProductCategoryController : Controller
    {

        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        // GET: ProductCategoryController
        public async Task<ActionResult> Index()
        {
            var productCategory = await _productCategoryService.GetAll();

            if (TempData["result"] != null)
            {
                ViewBag.message = TempData["result"];
            }

            return View(productCategory);
        }


        // GET: ProductCategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductCategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductCategoryRequest collection)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await _productCategoryService.CreateProductCategory(collection);

            if (result == true)
            {
                TempData["result"] = "Success";
                return RedirectToAction("Index");
            }

            TempData["result"] = "Failed";
            return View(collection);
        }

        // GET: ProductCategoryController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var productCategory = await _productCategoryService.GetById(id);

            return View(productCategory);
        }

        // POST: ProductCategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ProductCategoryRequest collection)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await _productCategoryService.UpdateProductCategory(id, collection);

            if (result == true)
            {
                TempData["result"] = "Success";
                return RedirectToAction("Index");
            }

            TempData["result"] = "Failed";
            return View(collection);
        }

        // GET: ProductCategoryController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _productCategoryService.GetById(id);
            return View(result);
        }

        // POST: ProductCategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            var result = await _productCategoryService.DeleteProductCategory(id);

            if (result == true)
            {
                TempData["result"] = "Success";
                return RedirectToAction("Index");
            }

            TempData["result"] = "Failed";
            return View(collection);
        }

        [HttpGet]
        public async Task<ActionResult> Hide(int id)
        {
            var result = await _productCategoryService.HideProductCategory(id);

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
