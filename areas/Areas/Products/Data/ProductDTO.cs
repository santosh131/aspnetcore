using areas.Areas.Products.Models;

namespace areas.Areas.Products.Data
{
    public class ProductDTO
    {
        public ProductsModel Product { get; set; }
        public List<ProductsModel> Products { get; set; }
    }
}
