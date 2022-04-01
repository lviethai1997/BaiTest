using Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.Cart;
using ViewModels.Catalog.Checkout;
using ViewModels.Catalog.ProductCategories;
using ViewModels.Catalog.Products;

namespace Services.Catalog.Products
{
    public interface IProductService
    {
        Task<bool> CreateProduct(ProductRequest request);

        Task<bool> UpdateProduct(int id, ProductRequest request);

        Task<bool> DeleteProduct(int id);

        Task<bool> HideProduct(int id);

        Task<List<ProductInCategoryRequest>> getProductByCateId(int id);

        Task<ProductRequest> GetById(int id);
        Task<List<ProductListRequest>> GetAll();

        Task<Product> FindById(int id);

        Task<CheckOutRequest> getCheckOut(string userName, List<CartItemRequest> request);
       
    }
}
