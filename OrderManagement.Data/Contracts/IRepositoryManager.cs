using OrderManagement.Data.Repositories;

namespace OrderManagement.Data.Contracts
{
    public interface IRepositoryManager
    {
        ICustomerRepository Customers { get; }
        IOrderRepository Orders { get; }
        Task SaveAsync();
    }
}
