using OrderManagement.Data.Contracts;

namespace OrderManagement.Data.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly OrderManagementDbContext _repositoryContext;
        private readonly Lazy<ICustomerRepository> _customerRepository;
        private readonly Lazy<IOrderRepository> _orderRepository;

        public RepositoryManager(OrderManagementDbContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _customerRepository = new Lazy<ICustomerRepository>(() => new CustomerRepository(repositoryContext));
            _orderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(repositoryContext));
        }

        public ICustomerRepository Customers => _customerRepository.Value;
        public IOrderRepository Orders => _orderRepository.Value;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
