namespace Application.Dtos
{
    public class OrderRequestDto
    {
        public int CustomerId { get; set; }
        public decimal Quantity { get; set; }
        public DateTime OrderedDate { get; set; }
        public List<OrderItemRequestDto> orderItems { get; set; } = new List<OrderItemRequestDto>();
    }
}
