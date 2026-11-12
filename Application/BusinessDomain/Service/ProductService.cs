using Application.BusinessDomain.IService;
using Application.Common;
using Application.Dtos.ResponseDtos;
using Application.IRepository;
using AutoMapper;
using Domain;

namespace Application.BusinessDomain.Service
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _repo;
        private readonly IMapper _mapper;
        public ProductService(IGenericRepository<Product> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Response<ProductResponseDto>> CreateProduct(Product product)
        {
            Response<ProductResponseDto> response = null;

            if (product == null)
                return Response<ProductResponseDto>.ErrorResponse("Please select product");

            var isCreated = await _repo.Create(product);
            if (!isCreated)
                return Response<ProductResponseDto>.ErrorResponse("Something went wrong!!! Please try again");

            var result = _mapper.Map<ProductResponseDto>(product);
            return Response<ProductResponseDto>.SuccessResponse(result, "Product Created successfully");
        }

        public async Task<Response<List<ProductResponseDto>>> GetAllProducts()
        {
            var products = _repo.GetAll();

            if (products == null || !products.Any())
                return Response<List<ProductResponseDto>>.ErrorResponse("No Products found");
            else
            {
                var result = _mapper.Map<List<ProductResponseDto>>(products);
                return Response<List<ProductResponseDto>>.SuccessResponse(result, "Products retrieved successfully!!");
            }
        }

        public async Task<Response<ProductResponseDto>> GetProductById(int id)
        {
            if (id == 0)
                return Response<ProductResponseDto>.ErrorResponse("Please provide product id");

            var data = await _repo.GetById(id);

            if (data == null)
            {
                return Response<ProductResponseDto>.SuccessResponse(null, "Product not found for the given id");
            }
            else
            {
                var result = _mapper.Map<ProductResponseDto>(data);
                return Response<ProductResponseDto>.SuccessResponse(result, "Product retrieved successfully.");
            }
        }

        public async Task<Response<ProductResponseDto>> UpdateProduct(Product product)
        {
            Response<Product> response = null;
            if (product == null)
            {
                return Response<ProductResponseDto>.ErrorResponse("Entity can not be null.");
            }
            var isUpdated = await _repo.Update(product);
            if (isUpdated)
            {
                return Response<ProductResponseDto>.SuccessResponse(null, "Product Updated successfully.");
            }
            else
            {
                return Response<ProductResponseDto>.ErrorResponse("Please try again.");
            }
        }
    }
}
