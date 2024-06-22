﻿using ShopBusiness.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DemoWebMVC.Models
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        [Display(Name = "Tên Sản phẩm")]
        public string? ProductName { get; set; }

        [Display(Name = "Mô tả")]
        public string? Description { get; set; }
        [Display(Name = "Nội dung")]
        public string? Ncontent { get; set; }
        [Display(Name = "Danh mục Sản phẩm")]
        public int CategoryId { get; set; }
        [Display(Name = "Ảnh")]
        public string? ImageUrl { get; set; }
        [Display(Name = "Giá cả")]
        [DisplayFormat(DataFormatString = "{0:N0}đ")]

        public decimal Price { get; set; }

        [Display(Name = "Ngày đăng")]
        public DateTime CreatePost { get; set; }

        public int UserPost { get; set; }

        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }

        [Display(Name = "Danh mục Sản phẩm")]
        public virtual Category? Category { get; set; } = null!;

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile? ImageFile { get; set; } = null!;

        [Display(Name = "Người đăng")]
        public virtual User? UserPostNavigation { get; set; } = null!;
    }
}
