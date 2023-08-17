using Microsoft.AspNetCore.Mvc;
using OrderManagement.Core.Contracts;
using OrderManagement.Core.Models.Requests;
using OrderManagement.Data.Entities;

namespace OrderManagement.API.Controllers
{
    [Route("orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrdersAsync()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("{orderId:long}")]
        public async Task<ActionResult<Order>> GetOrderByIdAsync(long orderId)
        {
            var order = await _orderService.GetOrderByIdAsync(orderId);
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrderAsync(CreateOrderRequest order)
        {
            var newOrder = await _orderService.CreateOrderAsync(order);
            return Created("/orders/" + newOrder.Id, newOrder);            
        }

        [HttpPatch("{orderId:long}")]
        public async Task<ActionResult<Order>> UpdateOrderStatusAsync(long orderId, OrderStatus orderStatus)
        {
            var updatedOrder = await _orderService.UpdateOrderStatus(orderId, orderStatus);
            return Ok(updatedOrder);
        }
    }
}