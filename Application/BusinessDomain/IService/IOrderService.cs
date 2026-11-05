using Application.Common;
using Application.Dtos;
using Application.Dtos.ResponseDtos;
using Domain;

namespace Application.BusinessDomain.IService
{
    public interface IOrderService
    {
        Task<Response<OrderResponseDto>> CreateOrder(OrderRequestDto order);
        Task<Response<OrderResponseDto>> GetOrderById(int id);
        Task<Response<IEnumerable<OrderResponseDto>>> GetAllOrders();
        Task<bool> UpdateOrder(Order order);
    }
}
