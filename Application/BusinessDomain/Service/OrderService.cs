using Application.BusinessDomain.IService;
using Application.Common;
using Application.Dtos;
using Application.Dtos.ResponseDtos;
using Application.IRepository;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.BusinessDomain.Service
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _repo;

        public OrderService(IGenericRepository<Order> repo)
        {
            _repo = repo;
        }
        public async Task<Response<OrderResponseDto>> CreateOrder(OrderRequestDto order)
        {
            Response<OrderResponseDto> response = null;

            if (order == null)
            {
                response = new Response<OrderResponseDto>
                {
                    Status = new Status
                    {
                        Success = false,
                        Message = "Entity can not be null"
                    },
                    Data = null
                };
                return response;
            }
            var OrderModel = new Order
            {
                CustomerId = order.CustomerId,
                OrderDate = DateTime.Now,
                Quantity = order.Quantity,
                OrderItems = order.orderItems.Select(item => new OrderItem
                {
                    ProductId = item.ProductId,
                }).ToList(),
            };
            var isCreated = await _repo.Create(OrderModel);

            if (isCreated)
            {
                response = new Response<OrderResponseDto>
                {
                    Status = new Status
                    {
                        Success = true,
                        Message = "Order submitted successfully"
                    },
                    Data = null
                };
            }
            else
            {
                response = new Response<OrderResponseDto>
                {
                    Status = new Status
                    {
                        Success = false,
                        Message = "Something went wrong, Please try again"
                    },
                    Data = null
                };
            }
            return response;
        }

        public async Task<Response<IEnumerable<OrderResponseDto>>> GetAllOrders()
        {
            Response<IEnumerable<OrderResponseDto>> response = null;

            var orderData = await _repo.GetAll()
                             .Include(c => c.Customer)
                             .Include(oi => oi.OrderItems)
                                .ThenInclude(p => p.Product)
                             .AsNoTracking()
                             .ToListAsync();
            if (orderData == null)
            {
                response = new Response<IEnumerable<OrderResponseDto>>
                {
                    Status = new Status
                    {
                        Success = true,
                        Message = "Orders not found"
                    },
                    Data = null
                };
                return response;
            }

            var OrderList = orderData.Select(order => new OrderResponseDto
            {
                CustomerName = order.Customer.Name,
                Quantity = order.Quantity,
                OrderItems = order.OrderItems.Select(oi => new OrderItemResponseDto
                {
                    Price = oi.Product.Price,
                    ProductName = oi.Product.Name,
                })
            });

            response = new Response<IEnumerable<OrderResponseDto>>
            {
                Status = new Status
                {
                    Success = true,
                    Message = "Orders retrieved successfully"
                },
                Data = OrderList
            };

            return response;
        }

        public async Task<Response<OrderResponseDto>> GetOrderById(int id)
        {
            Response<OrderResponseDto> response = null;
            if (id == 0)
                return Response<OrderResponseDto>.ErrorResponse("Please provide order id");

            var order = await _repo.GetAll()
                         .Include(c => c.Customer)
                         .Include(io => io.OrderItems)
                           .ThenInclude(p => p.Product)
                         .AsNoTracking()
                         .FirstOrDefaultAsync(o => o.Id == id);


            if (order == null)
                return Response<OrderResponseDto>.ErrorResponse("Order not found for the given ID.");

            var orderModel = new OrderResponseDto
            {
                CustomerName = order.Customer.Name,
                Quantity = order.Quantity,
                OrderItems = order.OrderItems.Select(oi => new OrderItemResponseDto
                {
                    Price = oi.Product.Price,
                    ProductName = oi.Product.Name,
                }).ToList(),
            };

            return Response<OrderResponseDto>.SuccessResponse(orderModel, "Order retrieved successfully");
        }

        public async Task<bool> UpdateOrder(Order order)
        {
            return await _repo.Update(order);
        }
    }
}
