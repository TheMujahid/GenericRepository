using Application.Dtos.ResponseDtos;
using AutoMapper;
using Domain;

namespace Application.Mapper
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductResponseDto>();

            CreateMap<OrderItem, OrderItemResponseDto>().ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                                                        .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product.Price));
        }
    }
}
