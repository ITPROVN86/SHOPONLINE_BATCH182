using BusinessObjects;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        [Display(Name = "Danh mục sản phẩm")]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
