using Data.EF;
using Data.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ViewModels.Catalog.ProductCategories;

namespace Services.Catalog.ProductCategories
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly ShopDbContext _context;

        public ProductCategoryService(ShopDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateProductCategory(ProductCategoryRequest request)
        {
            var productCategory = new ProductCategory()
            {
                Name = request.Name,
                ParentID = request.ParentID,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now,
                Status = request.Status,
            };

            await _context.ProductCategories.AddAsync(productCategory);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProductCategory(int id)
        {
            var FindProductCategory = await _context.ProductCategories.FindAsync(id);

            if (FindProductCategory != null)
            {
                _context.Remove(FindProductCategory);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<ProductCategory>> GetAll()
        {
            var getAll = await _context.ProductCategories.Select(x => new ProductCategory()
            {
                ID = x.ID,
                Name = x.Name,
                ParentID = x.ParentID,
                CreateTime = x.CreateTime,
                UpdateTime = x.UpdateTime,
                Status = x.Status,
            }).ToListAsync();

            return new List<ProductCategory>(getAll);
        }

        public async Task<ProductCategory> GetById(int id)
        {
            var FindById = await _context.ProductCategories.FindAsync(id);

            if (FindById == null)
            {
                return null;
            }
          

            return FindById;
        }

        public async Task<List<CbCategories>> getCategory()
        {
            var category = await _context.ProductCategories.OrderBy(x => x.ID).Select(x => new CbCategories()
            {
                ID=x.ID,
                Name=x.Name
            }).ToListAsync();

            return category;
        }

        public async Task<bool> HideProductCategory(int id)
        {
            var findById = await _context.ProductCategories.FindAsync(id);
            if (findById != null)
            {
                findById.Status = findById.Status == 0 ? 1 : 0;
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateProductCategory(int id, ProductCategoryRequest request)
        {
            var findByid = await _context.ProductCategories.FindAsync(id);

            if (findByid != null)
            {
                findByid.Name = request.Name;
                findByid.ParentID = request.ParentID;
                findByid.UpdateTime = DateTime.Now;
                findByid.CreateTime = request.CreateTime;
                findByid.Status = request.Status;

                await _context.SaveChangesAsync();

                return true;
            }
            return false;
        }
    }
}