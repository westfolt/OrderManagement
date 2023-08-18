using OrderManagement.Core.Models.Requests;
using OrderManagement.Data.Entities;

namespace OrderManagement.Core.Contracts
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(long orderId);
        Task<Order> CreateOrderAsync(CreateOrderRequest order);
        Task<Order> UpdateOrderStatus(long orderId, OrderStatus newStatus);
    }
}
