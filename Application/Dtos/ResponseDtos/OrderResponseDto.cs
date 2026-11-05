namespace Application.Dtos.ResponseDtos
{
    public class OrderResponseDto
    {
        public string CustomerName { get; set; }
        public decimal Quantity { get; set; }
        public IEnumerable<OrderItemResponseDto> OrderItems { get; set; } = new List<OrderItemResponseDto>();
    }
}
