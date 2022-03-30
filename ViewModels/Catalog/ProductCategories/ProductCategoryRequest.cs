using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Catalog.ProductCategories
{
    public class ProductCategoryRequest
    {
        public string Name { get; set; }

        public int ParentID { get; set; }

        public int Status { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }

    }
}
