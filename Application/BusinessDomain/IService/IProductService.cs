using Application.Common;
using Application.Dtos.ResponseDtos;
using Domain;

namespace Application.BusinessDomain.IService
{
    public interface IProductService
    {
        Task<Response<ProductResponseDto>> CreateProduct(Product product);
        Task<Response<ProductResponseDto>> GetProductById(int id);
        Task<Response<List<ProductResponseDto>>> GetAllProducts();
        Task<Response<ProductResponseDto>> UpdateProduct(Product product);
    }
}
