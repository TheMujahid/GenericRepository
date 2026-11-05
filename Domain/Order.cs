namespace Domain
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        // Foriegn keys
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public decimal Quantity { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
