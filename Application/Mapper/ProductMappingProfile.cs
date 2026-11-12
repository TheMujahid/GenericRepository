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
        }
    }
}
