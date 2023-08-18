using OrderManagement.Data.Entities;

namespace OrderManagement.Data.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order?> GetOrderByIdAsync(long orderId);
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
    }
}
