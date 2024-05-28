using CodeCrafters_backend_teamwork.src.DTOs;
using CodeCrafters_backend_teamwork.src.Entities;

namespace CodeCrafters_backend_teamwork.src.Abstractions
{
    public interface IOrderCheckoutService
    {
        public IEnumerable<OrderCheckoutReadDto> FindMany();
        public OrderCheckout? FindOne(Guid orderCheckoutId);
        public IEnumerable<OrderCheckoutReadDto> CreateOne(OrderCheckoutCreateDto newOrderCheckout);
        public OrderCheckout UpdateOne(Guid ordercheckoutId, OrderCheckout updateOrdercheckout);
        public IEnumerable<OrderCheckout>? DeleteOne(Guid orderCheckoutId);
        public IEnumerable<OrderCheckout> Checkout(List<OrderItemCreateDto> neworderItemCreateDtos); 
    }
}