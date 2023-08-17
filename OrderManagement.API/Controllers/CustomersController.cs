using Microsoft.AspNetCore.Mvc;
using OrderManagement.Core.Contracts;
using OrderManagement.Core.Models.Requests;
using OrderManagement.Data.Entities;

namespace OrderManagement.API.Controllers
{
    [Route("customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomersAsync()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return Ok(customers);
        }

        [HttpGet("{customerId:long}")]
        public async Task<ActionResult<Customer>> GetCustomerByIdAsync(long customerId)
        {
            var customer = await _customerService.GetCustomerByIdAsync(customerId);
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomerAsync(CreateCustomerRequest customer)
        {
            var newCustomer = await _customerService.CreateCustomerAsync(customer);
            return Created("/customers/" + newCustomer.Id, newCustomer);            
        }
    }
}
