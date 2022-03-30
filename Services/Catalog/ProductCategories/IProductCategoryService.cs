using Data.Entites;
using ViewModels.Catalog.ProductCategories;

namespace Services.Catalog.ProductCategories
{
    public interface IProductCategoryService
    {
        Task<bool> CreateProductCategory(ProductCategoryRequest request);

        Task<bool> UpdateProductCategory(int id,ProductCategoryRequest request);

        Task<bool> DeleteProductCategory(int id);

        Task<bool> HideProductCategory(int id);

        Task<ProductCategory> GetById(int id);
        Task<List<ProductCategory>> GetAll();

        Task<List<CbCategories>> getCategory();
    }
}