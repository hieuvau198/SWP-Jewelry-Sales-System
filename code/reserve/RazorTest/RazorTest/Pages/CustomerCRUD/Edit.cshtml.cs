using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RazorTest.Models;
using RazorTest.Services;
using System.Threading.Tasks;

namespace RazorTest.Pages.CustomerCRUD
{
    public class EditModel : PageModel
    {
        private readonly CustomerService _customerService;
        private readonly ILogger<EditModel> _logger;
        public EditModel(CustomerService apiService, ILogger<EditModel> logger, CustomerService customerService)
        {
            _customerService = customerService;
            _logger = logger;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                _logger.LogError("ID is null");
                return NotFound();
            }

            Customer = await _customerService.GetCustomerByIdAsync(id);

            if (Customer == null)
            {
                _logger.LogError($"Customer not found for ID {id}");
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                foreach (var modelStateKey in ModelState.Keys)
                {
                    var modelStateVal = ModelState[modelStateKey];
                    foreach (var error in modelStateVal.Errors)
                    {
                        _logger.LogError($"Key: {modelStateKey}, Error: {error.ErrorMessage}");
                    }
                }

                return Page();
            }

            _logger.LogInformation($"Updating customer with ID {Customer.CustomerId}");
            _logger.LogInformation($"Discount details: {JsonConvert.SerializeObject(Customer)}");

            var response = await _customerService.UpdateCustomerAsync(Customer);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"Failed to update customer. Status Code: {response.StatusCode}");
                ModelState.AddModelError(string.Empty, "An error occurred while updating the customer.");
                return Page();
            }

            _logger.LogInformation("Successfully updated customer");
            return RedirectToPage("./CustomerDetail");
        }
    }
}
