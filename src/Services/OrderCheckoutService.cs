using AutoMapper;
using CodeCrafters_backend_teamwork.src.Abstractions;
using CodeCrafters_backend_teamwork.src.DTOs;
using CodeCrafters_backend_teamwork.src.Entities;

namespace CodeCrafters_backend_teamwork.src.Services
{
    public class OrderCheckoutService : IOrderCheckoutService
    {
        private IOrderCheckoutRepository _orderCheckoutRepo;
        private IOrderItemRepository _orderItemRepo;
        private readonly IMapper _mapper;

        public OrderCheckoutService(IOrderCheckoutRepository orderCheckoutRepository,
        IMapper mapper, IOrderItemRepository orderItemRepo)
        {
            _orderCheckoutRepo = orderCheckoutRepository;
            _orderItemRepo = orderItemRepo;
            _mapper = mapper;
        }

        public IEnumerable<OrderCheckoutReadDto> CreateOne(OrderCheckoutCreateDto newOrderCheckout)
        {
            OrderCheckout orderCheckout = _mapper.Map<OrderCheckout>(newOrderCheckout);
            var orderCheckoutList = _orderCheckoutRepo.CreateOne(orderCheckout);
            var mappedOrdercheckoutList = orderCheckoutList.Select(_mapper.Map<OrderCheckoutReadDto>);
            return mappedOrdercheckoutList;
        }

        public IEnumerable<OrderCheckoutReadDto> FindMany()
        {
            IEnumerable<OrderCheckout> orderCheckouts = _orderCheckoutRepo.FindMany();
            return orderCheckouts.Select(_mapper.Map<OrderCheckoutReadDto>);
        }


        public OrderCheckout? FindOne(Guid orderCheckoutId)
        {
            return _orderCheckoutRepo.FindOne(orderCheckoutId);
        }


        public OrderCheckout UpdateOne(Guid orderCheckoutId, OrderCheckout updatedCheckout)
        {
            return _orderCheckoutRepo.UpdateOne(orderCheckoutId, updatedCheckout);
        }

        public IEnumerable<OrderCheckout>? DeleteOne(Guid orderCheckoutId)
        {
            return _orderCheckoutRepo.DeleteOne(orderCheckoutId);
        }


        public IEnumerable<OrderCheckout> Checkout(List<OrderItemCreateDto> orderItemCreateDtos)
        {
            // create an Order object 
            var orderCheckout = new OrderCheckout();
            // run for loop for list of orderItemCreateDtos
            foreach (var item in orderItemCreateDtos)
            {
                // when you run for loop, it will return a single item 
                var orderItem = new OrderItem(); ;

                orderItem.OrderCheckoutId = orderCheckout.Id;
                orderItem.StockId = item.StockId;
                orderItem.Quantity = item.Quantity;
                orderItem.Price = item.Price;
                // inside for loop, remember to inject _orderItemRepo and then _orderItemRepo.Create(orderItem)
                _orderItemRepo.CreateOne(orderItem);

            }
            // mock data for userId, paymentId, ShippingId
            orderCheckout.Payment = "string";
            orderCheckout.Shipping = "string";
            orderCheckout.UserId = Guid.NewGuid();
            // outside for loop, save order inside order table 
            _orderCheckoutRepo.CreateOne(orderCheckout);
            return (IEnumerable<OrderCheckout>)orderCheckout;
        }

      
    }
}