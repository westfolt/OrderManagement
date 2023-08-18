using Microsoft.EntityFrameworkCore;
using OrderManagement.Data.Entities;

namespace OrderManagement.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private OrderManagementDbContext _context;

        public OrderRepository(OrderManagementDbContext context)
        {
            _context = context;
        }

        public void CreateOrder(Order order)
        {
            _context.Orders.Add(order);
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(long orderId)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public void UpdateOrder(Order order)
        {
            _context.Update(order);
        }
    }
}
