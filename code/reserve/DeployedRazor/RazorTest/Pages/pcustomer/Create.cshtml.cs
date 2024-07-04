using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using System.Threading.Tasks;

namespace RazorTest.Pages.pcustomer
{
    public class CreateModel : PageModel
    {
        private readonly CustomerService _customerService;
        private readonly ILogger<CreateModel> _logger;
        private readonly ApiService _apiService;

        public CreateModel(CustomerService customerService, ILogger<CreateModel> logger, ApiService apiService)
        {
            _customerService = customerService;
            _logger = logger;
            _apiService = apiService;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public IActionResult OnGet()
        {
            // Verify user
            List<string> roles = new List<string>
            {
                "Manager",
                "Sale",
                "Cashier",
                "Admin"
            };
            if( !_apiService.VerifyAuth(HttpContext, roles) )
            {
                return RedirectToPage("/Authentication/AccessDenied");
            }

            // Initialize the Customer with a new ID
            Customer = new Customer
            {
                CustomerId = Guid.NewGuid().ToString(),
                AttendDate = DateTime.Now,
            };

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

            // Check if DiscountId is still empty and generate it
            if (string.IsNullOrEmpty(Customer.CustomerId))
            {
                Customer.CustomerId = Guid.NewGuid().ToString();
            }

            var response = await _customerService.CreateCustomerAsync(Customer);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/pcustomer/CustomerDetail");
            }

            ModelState.AddModelError(string.Empty, "An error occurred while creating the customer.");
            _logger.LogError($"Failed to create customer. Status Code: {response.StatusCode}");
            return Page();
        }
    }
}
