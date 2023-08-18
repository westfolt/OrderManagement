using Microsoft.EntityFrameworkCore;
using OrderManagement.Data.Entities;

namespace OrderManagement.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private OrderManagementDbContext _context;

        public CustomerRepository(OrderManagementDbContext context)
        {
            _context = context;
        }

        public void CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers.Include(c => c.Orders).ToListAsync();
        }

        public async Task<Customer?> GetCustomerByIdAsync(long customerId)
        {
            return await _context.Customers.Include(c => c.Orders).FirstOrDefaultAsync(c => c.Id == customerId);
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Update(customer);
        }
    }
}
