using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;
using System.Threading.Tasks;


namespace RazorTest.Pages.Sale
{
    public class CreateModel : PageModel
    {
        public const string SessionKeyAuthState = "_AuthState";
        public const string SessionKeyUserObject = "_UserObject";

        private readonly CustomerService _customerService;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(CustomerService customerService, ILogger<CreateModel> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public void OnGet()
        {
            // Initialize the Customer with a new ID
            Customer = new Customer
            {
                CustomerId = Guid.NewGuid().ToString(),
                AttendDate = DateTime.Now,
            };
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
                return RedirectToPage("/Sale/ViewCart");
            }

            ModelState.AddModelError(string.Empty, "An error occurred while creating the customer.");
            _logger.LogError($"Failed to create customer. Status Code: {response.StatusCode}");
            return Page();
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
