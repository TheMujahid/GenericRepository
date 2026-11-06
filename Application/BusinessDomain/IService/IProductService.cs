using Application.Common;
using Application.Dtos.ResponseDtos;
using Domain;

namespace Application.BusinessDomain.IService
{
    public interface IProductService
    {
        Task<Response<ProductResponseDto>> CreateProduct(Product product);
        Task<Response<Product>> GetProductById(int id);
        Task<Response<IQueryable<Product>>> GetAllProducts();
        Task<Response<Product>> UpdateProduct(Product product);
    }
}
