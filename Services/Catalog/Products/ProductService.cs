using Data.EF;
using Data.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Services.Common;
using System.Net.Http.Headers;
using ViewModels.Catalog.Cart;
using ViewModels.Catalog.Checkout;
using ViewModels.Catalog.ProductCategories;
using ViewModels.Catalog.Products;

namespace Services.Catalog.Products
{
    public class ProductService : IProductService
    {
        private readonly ShopDbContext _shopDbContext;
        private readonly IStorageService _storageService;

        public ProductService(ShopDbContext shopDbContext, IStorageService serviceProvider)
        {
            _shopDbContext = shopDbContext;
            _storageService = serviceProvider;
        }

        public async Task<bool> CreateProduct(ProductRequest request)
        {
            var product = new Product()
            {
                Name = request.Name,
                CategoryID = request.CategoryID,
                Quantity = request.Quantity,
                Price = request.Price,
                Description = request.Description,
                CreateTime = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Status = request.Status

            };

            if (request.Image != null)
            {
                product.ImagePath = await this.SaveFile(request.Image);
            }

            _shopDbContext.Add(product);
            await _shopDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _shopDbContext.Products.FirstOrDefaultAsync(x => x.ID == id);
            await _storageService.DeleteFileAsync(product.ImagePath);
            _shopDbContext.Remove(product);
            await _shopDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Product> FindById(int id)
        {
            var product = await _shopDbContext.Products.Where(x => x.ID == id).FirstOrDefaultAsync();

            return product;
        }

        public async Task<List<Product>> GetAll()
        {
            var products = await _shopDbContext.Products.Select(x => new Product()
            {
                ImagePath = x.ImagePath,
                ID = x.ID,
                Name = x.Name,
                CategoryID = x.CategoryID,
                Quantity = x.Quantity,
                Price = x.Price,
                Description = x.Description,
                CreateTime = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Status = x.Status
            }).ToListAsync();

            return products;
        }

        public async Task<ProductRequest> GetById(int id)
        {
            var product = await _shopDbContext.Products.FindAsync(id);
            if (product == null)
            {
                return null;
            }

            var result = new ProductRequest()
            {
                Name = product.Name,
                CategoryID = product.CategoryID,
                Quantity = product.Quantity,
                Price = product.Price,
                Description = product.Description,
                ImagePath = product.ImagePath,
                Status = product.Status
            };

            return result;
        }

        public async Task<CheckOutRequest> getCheckOut(string userName, List<CartItemRequest> request)
        {
            var getUser = await _shopDbContext.User.Where(x=>x.Username == userName.Trim()).FirstOrDefaultAsync();

            var cars = new CheckOutRequest()
            {
                user = getUser,
                carts = request
            };

            return cars;

        }

        public async Task<List<ProductInCategoryRequest>> getProductByCateId(int id)
        {
            var products = from p in _shopDbContext.Products
                           join pc in _shopDbContext.ProductCategories on p.CategoryID equals pc.ID
                           where p.CategoryID == id && p.Status == 0
                           select new { p, pc };

            var reuslt = await products.Select(x => new ProductInCategoryRequest()
            {
                ProductId = x.p.ID,
                ProductName = x.p.Name,
                Price = x.p.Price,
                ImagePath = x.p.ImagePath,
                CateId = x.pc.ID,
                CateName = x.pc.Name,
            }).ToListAsync();

            return reuslt;
        }

        public async Task<bool> HideProduct(int id)
        {
            var product = await _shopDbContext.Products.FindAsync(id);

            product.Status = product.Status == 0 ? 1 : 0;

            await _shopDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateProduct(int id, ProductRequest request)
        {
            var product = await _shopDbContext.Products.FindAsync(id);

            product.Name = request.Name;
            product.CategoryID = request.CategoryID;
            product.Quantity = request.Quantity;
            product.Price = request.Price;
            product.Description = request.Description;
            product.UpdatedDate = DateTime.Now;
            product.Status = request.Status;

            if (request.Image != null)
            {
                product.ImagePath = await this.SaveFile(request.Image);
            }

            _shopDbContext.Update(product);
            await _shopDbContext.SaveChangesAsync();

            return true;
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFilename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFilename)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }
    }
}