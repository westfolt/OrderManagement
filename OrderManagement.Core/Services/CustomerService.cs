using FluentValidation;
using OrderManagement.Core.Contracts;
using OrderManagement.Core.Exceptions;
using OrderManagement.Core.Models.Requests;
using OrderManagement.Data.Contracts;
using OrderManagement.Data.Entities;

namespace OrderManagement.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IValidator<CreateCustomerRequest> _validator;
        private readonly IRepositoryManager _repository;

        public CustomerService(IValidator<CreateCustomerRequest> validator,
            IRepositoryManager repository)
        {
            _validator = validator;
            _repository = repository;
        }

        public async Task<Customer> CreateCustomerAsync(CreateCustomerRequest customer)
        {
            var validationResult = _validator.Validate(customer);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var newCustomer = new Customer
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Phone = customer.Phone
            };
            try
            {
                _repository.Customers.CreateCustomer(newCustomer);
                await _repository.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new DomainException("Something went wrong while saving the customer", ex);
            }

            return newCustomer;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            var customers = await _repository.Customers.GetAllCustomersAsync();

            if (!customers.Any())
                throw new NotFoundException("No customers found");

            return customers;
        }

        public async Task<Customer> GetCustomerByIdAsync(long customerId)
        {
            var customer = await _repository.Customers.GetCustomerByIdAsync(customerId);

            if (customer == null)
                throw new NotFoundException($"Order with id {customerId} not found");

            return customer;
        }

        public async Task UpdateCustomerConfirmedOrders(long customerId)
        {
            var customer = await _repository.Customers.GetCustomerByIdAsync(customerId);

            if (customer == null)
                throw new NotFoundException($"Order with id {customerId} not found");

            if (customer.Orders.Count > customer.NumberOfConfirmedOrders)
            {
                customer.NumberOfConfirmedOrders += 1;
                try
                {
                    _repository.Customers.UpdateCustomer(customer);
                    await _repository.SaveAsync();
                }
                catch (Exception ex)
                {
                    throw new DomainException("Something went wrong while saving the customer", ex);
                }
            }
        }
    }
}
