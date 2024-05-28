namespace CodeCrafters_backend_teamwork.src.DTOs
{
    public class OrderItemCreateDto
    {
        public int Quantity { get; set; }
        public Guid StockId { get; set; }
        public double Price { get; set; }
        public Guid OrderCheckoutId { get; set; }
    }
}