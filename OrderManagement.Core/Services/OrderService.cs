using FluentValidation;
using OrderManagement.Core.Contracts;
using OrderManagement.Core.Exceptions;
using OrderManagement.Core.Models.Messages;
using OrderManagement.Core.Models.Requests;
using OrderManagement.Data.Contracts;
using OrderManagement.Data.Entities;

namespace OrderManagement.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IValidator<CreateOrderRequest> _validator;
        private readonly IRepositoryManager _repository;
        private readonly IServiceBusService<OrderCreatedMessage> _serviceBusService;

        public OrderService(IValidator<CreateOrderRequest> validator,
            IRepositoryManager repository,
            IServiceBusService<OrderCreatedMessage> serviceBusService)
        {
            _validator = validator;
            _repository = repository;
            _serviceBusService = serviceBusService;
        }

        public async Task<Order> CreateOrderAsync(CreateOrderRequest order)
        {
            var validationResult = _validator.Validate(order);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var newOrder = new Order
            {
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
                OrderNumber = order.OrderNumber,
                Status = order.Status
            };

            try
            {
                _repository.Orders.CreateOrder(newOrder);
                await _repository.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new DomainException("Something went wrong while saving the order", ex);
            }

            var messageContent = new OrderCreatedMessage
            {
                CustomerId = newOrder.CustomerId,
                OrderDate = newOrder.OrderDate,
                OrderNumber = newOrder.OrderNumber,
                Status = newOrder.Status
            };
            await _serviceBusService.SendMessageAsync(messageContent);

            return newOrder;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            var orders = await _repository.Orders.GetAllOrdersAsync();

            if (!orders.Any())
                throw new NotFoundException("No orders found");

            return orders;
        }

        public async Task<Order> GetOrderByIdAsync(long orderId)
        {
            var order = await _repository.Orders.GetOrderByIdAsync(orderId);

            if (order == null)
                throw new NotFoundException($"Order with id {orderId} not found");

            return order;
        }

        public async Task<Order> UpdateOrderStatus(long orderId, OrderStatus newStatus)
        {
            var order = await GetOrderByIdAsync(orderId);

            order.Status = newStatus;

            _repository.Orders.UpdateOrder(order);
            await _repository.SaveAsync();

            return order;
        }
    }
}
