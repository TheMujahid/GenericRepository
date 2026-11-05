using Application.BusinessDomain.IService;
using Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WEP_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _order;

        public OrderController(IOrderService order)
        {
            _order = order;
        }

        [HttpPost]
        [Route("CreateOrder")]
        public async Task<IActionResult> CreateOrder(OrderRequestDto order)
        {
            var data = await _order.CreateOrder(order);
            return Ok(data);
        }

        [HttpGet]
        [Route("GetOrderList")]
        public async Task<IActionResult> GetOrderList()
        {
            var data = await _order.GetAllOrders();
            return Ok(data);
        }

        [HttpGet]
        [Route("GetOrderById/{Id}")]
        public async Task<IActionResult> GetOrderById(int Id)
        {
            var data = await _order.GetOrderById(Id);
            return Ok(data);
        }
    }
}
