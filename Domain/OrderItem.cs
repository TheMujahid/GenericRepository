namespace Domain
{
    public class OrderItem
    {
        public int Id { get; set; }
        // Foriegn keys
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        //Navigation Properties
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
