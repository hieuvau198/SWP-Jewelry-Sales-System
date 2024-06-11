using JewelBO;
using JewelService.ServiceCustomer;
using Microsoft.AspNetCore.Mvc;

namespace JewelAPI.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_customerService.GetCustomers());
        }

        [HttpGet("{customerId}")]
        public IActionResult Get(string customerId)
        {
            if (string.IsNullOrWhiteSpace(customerId))
            {
                return BadRequest(new { message = "Invalid customer ID." });
            }

            var customer = _customerService.GetCustomer(customerId);
            if (customer == null)
            {
                return NotFound(new { message = "Customer not found." });
            }

            return Ok(customer);
        }

        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            try
            {
                return Ok(_customerService.AddCustomer(customer));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"An error occurred: {ex.Message}" });
            }
        }

        [HttpPut]
        public IActionResult Put(Customer customer)
        {
            try
            {
                return Ok(_customerService.UpdateCustomer(customer));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"An error occurred: {ex.Message}" });
            }
        }

        [HttpDelete("{customerId}")]
        public IActionResult Delete(string customerId)
        {
            try
            {
                return Ok(_customerService.RemoveCustomer(customerId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"An error occurred: {ex.Message}" });
            }
        }
    }
}
