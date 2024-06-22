using AutoMapper;
using ShopBusiness.Models;

namespace DemoWebMVC.Models
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() {
            CreateMap<Product, ProductDTO>();
        }
    }
}
