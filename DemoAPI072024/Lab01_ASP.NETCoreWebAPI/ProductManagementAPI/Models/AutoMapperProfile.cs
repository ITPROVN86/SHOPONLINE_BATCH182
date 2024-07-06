using AutoMapper;
using BusinessObjects;
using BusinessObjects.DTO;

namespace ProductManagementWebClient.Models
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDTO>().ForMember(d => d.CategoryName, o => o.MapFrom(src => src.Category.CategoryName));
        }
    }
}
