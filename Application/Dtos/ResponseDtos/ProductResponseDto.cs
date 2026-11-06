namespace Application.Dtos.ResponseDtos
{
    public class ProductResponseDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ICollection<OrderItemResponseDto> OrderItems = new List<OrderItemResponseDto>();
    }
}
