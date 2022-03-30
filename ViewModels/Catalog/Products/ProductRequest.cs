using Microsoft.AspNetCore.Http;

namespace ViewModels.Catalog.Products
{
    public class ProductRequest
    {
        public string Name { get; set; }

        public int CategoryID { get; set; }

        public int Quantity { get; set; }

        public IFormFile Image { get; set; }

        public string? ImagePath { get; set; }

        public Decimal Price { get; set; }

        public string Description { get; set; }

        public DateTime? CreateTime { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public int Status { get; set; }
    }
}