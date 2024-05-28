using CodeCrafters_backend_teamwork.src.Abstractions;
using CodeCrafters_backend_teamwork.src.DTOs;
using CodeCrafters_backend_teamwork.src.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CodeCrafters_backend_teamwork.src.Controllers
{
    public class OrderCheckoutController : CustomizedController
    {
        private IOrderCheckoutService _orderCheckoutService;


        public OrderCheckoutController (IOrderCheckoutService orderCheckoutService)

        { 
            _orderCheckoutService = orderCheckoutService;

        }



        [HttpGet]
        public ActionResult<IEnumerable<OrderCheckoutReadDto>> FindMany()
        {

            return Ok( _orderCheckoutService.FindMany());

        }

        [HttpGet("{orderCheckoutId}")]
        public OrderCheckout? FindOne(Guid orderCheckoutId)
        {

            return _orderCheckoutService.FindOne(orderCheckoutId);

        }


        [HttpPost]
        public ActionResult<IEnumerable<OrderCheckoutReadDto>> CreateOne([FromBody] OrderCheckoutCreateDto  newOrderCheckout)

        {

            return CreatedAtAction(nameof(CreateOne), _orderCheckoutService.CreateOne(newOrderCheckout));

        }



        [HttpDelete("{orderCheckoutId}")]
        public IEnumerable<OrderCheckout>? DeleteOne([FromRoute] Guid orderCheckoutId)
        {
            return _orderCheckoutService.DeleteOne(orderCheckoutId);
        }

        [HttpPatch("{orderCheckoutId}")]
        public OrderCheckout UpdateOne(Guid orderCheckoutId, OrderCheckout updatedCheckout)
        {
            return _orderCheckoutService.UpdateOne(orderCheckoutId, updatedCheckout);
        }

        [HttpPost("/checkout")]
        public IEnumerable<OrderCheckout> Checkout(List<OrderItemCreateDto> neworderItemCreateDtos)
        {
            return _orderCheckoutService.Checkout(neworderItemCreateDtos); 
        }
}}