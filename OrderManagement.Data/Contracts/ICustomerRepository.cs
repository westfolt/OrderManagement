using OrderManagement.Data.Entities;

namespace OrderManagement.Data.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer?> GetCustomerByIdAsync(long customerId);
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
    }
}
