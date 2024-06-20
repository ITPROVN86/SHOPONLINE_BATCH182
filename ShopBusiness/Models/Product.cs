using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopBusiness.Models;

public partial class Product
{
    public int ProductId { get; set; }

    [Display(Name ="Tên Sản phẩm")]
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
    public decimal Price { get; set; }

    [Display(Name = "Ngày đăng")]
    public DateTime CreatePost { get; set; }

    public int UserPost { get; set; }

    [Display(Name = "Trạng thái")]
    public bool Status { get; set; }

    [Display(Name = "Danh mục Sản phẩm")]
    public virtual Category? Category { get; set; } = null!;

    [Display(Name = "Người đăng")]
    public virtual User? UserPostNavigation { get; set; } = null!;
}
