using OrderManagement.Core.Models.Requests;
using OrderManagement.Data.Entities;

namespace OrderManagement.Core.Contracts
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(long customerId);
        Task<Customer> CreateCustomerAsync(CreateCustomerRequest customer);
        Task UpdateCustomerConfirmedOrders(long customerId);
    }
}
