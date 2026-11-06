using Application.BusinessDomain.IService;
using Application.Common;
using Application.Dtos.ResponseDtos;
using Application.IRepository;
using Domain;

namespace Application.BusinessDomain.Service
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _repo;
        public ProductService(IGenericRepository<Product> repo)
        {
            _repo = repo;
        }

        public async Task<Response<ProductResponseDto>> CreateProduct(Product product)
        {
            Response<ProductResponseDto> response = null;

            if (product == null)
                return Response<ProductResponseDto>.ErrorResponse("Please select product");

            var isCreated = await _repo.Create(product);
            if (!isCreated)
                return Response<ProductResponseDto>.ErrorResponse("Something went wrong!!! Please try again");

            var model = new ProductResponseDto
            {
                Name = product.Name,
                Price = product.Price,

                OrderItems = product.OrderItems.Select(io => new OrderItemResponseDto
                {
                    Price = io.Product.Price,
                    ProductName = io.Product.Name,
                }).ToList()
            };

            return Response<ProductResponseDto>.SuccessResponse(model, "Product Created successfully");
        }

        public async Task<Response<IQueryable<Product>>> GetAllProducts()
        {
            Response<IQueryable<Product>> response = null;
            var products = _repo.GetAll();

            if (products == null)
            {
                response = new Response<IQueryable<Product>>
                {
                    Status = new Status
                    {
                        Success = true,
                        Message = "No products found"
                    },
                    Data = null
                };
            }
            else
            {
                response = new Response<IQueryable<Product>>
                {
                    Status = new Status
                    {
                        Success = true,
                        Message = "Products retrieved successfully!!"
                    },
                    Data = products
                };
            }
            return response;
        }

        public async Task<Response<Product>> GetProductById(int id)
        {
            Response<Product> response = null;

            if (id == 0)
            {
                response = new Response<Product>
                {
                    Status = new Status
                    {
                        Success = false,
                        Message = "Please provide id"
                    },
                    Data = null
                };
                return response;
            }
            var data = await _repo.GetById(id);
            if (data == null)
            {
                response = new Response<Product>
                {
                    Status = new Status
                    {
                        Success = false,
                        Message = "Product not found for the given id"
                    },
                    Data = null
                };
            }
            else
            {
                response = new Response<Product>
                {
                    Status = new Status
                    {
                        Success = true,
                        Message = "Product retrieved successfully"
                    },
                    Data = data
                };
            }
            return response;
        }

        public async Task<Response<Product>> UpdateProduct(Product product)
        {
            Response<Product> response = null;
            if (product == null)
            {
                response = new Response<Product>
                {
                    Status = new Status
                    {
                        Success = false,
                        Message = "Message can not be null."
                    }
                };
                return response;
            }
            var isUpdated = await _repo.Update(product);
            if (isUpdated)
            {
                response = new Response<Product>
                {
                    Status = new Status
                    {
                        Success = true,
                        Message = "Item updated successfully"
                    },
                    Data = product
                };
            }
            else
            {
                response = new Response<Product>
                {
                    Status = new Status
                    {
                        Success = false,
                        Message = "Sorry Please try again"
                    }
                };
            }
            return response;
        }
    }
}
