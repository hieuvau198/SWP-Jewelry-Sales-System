using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;
using System.Threading.Tasks;

namespace RazorTest.Pages.pcustomer
{
    public class EditModel : PageModel
    {
        public const string SessionKeyAuthState = "_AuthState";
        public const string SessionKeyUserObject = "_UserObject";

        private readonly CustomerService _customerService;
        private readonly ApiService _apiService;
        private readonly ILogger<EditModel> _logger;
        public EditModel(ApiService apiService, ILogger<EditModel> logger, CustomerService customerService)
        {
            _apiService = apiService;
            _customerService = customerService;
            _logger = logger;
        }

        public User User { get; set; }

        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            // Verify user
            List<string> roles = new List<string>
            {
                "Manager",
                "Sale",
                "Cashier",
                "Admin"
            };
            if (!_apiService.VerifyAuth(HttpContext, roles))
            {
                return RedirectToPage("/Authentication/AccessDenied");
            }

            // Process data
            User = HttpContext.Session.GetObject<User>(SessionKeyUserObject);

            // Process results
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

        public bool VerifyAuth(string role)
        {
            bool result = false;
            bool isAuthenticated = HttpContext.Session.GetObject<bool>(SessionKeyAuthState);
            User user = HttpContext.Session.GetObject<User>(SessionKeyUserObject);
            if (isAuthenticated && user != null)
            {
                if (user.Role == role)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
