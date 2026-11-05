using Application.Common;
using Domain;

namespace Application.BusinessDomain.IService
{
    public interface IProductService
    {
        Task<Response<Product>> CreateProduct(Product product);
        Task<Response<Product>> GetProductById(int id);
        Task<Response<IQueryable<Product>>> GetAllProducts();
        Task<Response<Product>> UpdateProduct(Product product);
    }
}
