using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;
using System.Threading.Tasks;

namespace RazorTest.Pages.pcustomer
{
    public class DeleteModel : PageModel
    {
        public const string SessionKeyUserObject = "_UserObject";
        public const string SessionKeyAuthState = "_AuthState";
        private readonly CustomerService _customerService;

        private readonly ApiService _apiService;

        public DeleteModel(CustomerService customerService, ApiService apiService)
        {
            _customerService = customerService;
            _apiService = apiService;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public User User { get; set; }


        public async Task<IActionResult> OnGetAsync(string id)
        {
            // Verify user
            List<string> roles = new List<string>
            {
                "Manager",
                "Admin"
            };
            if (!_apiService.VerifyAuth(HttpContext, roles))
            {
                return RedirectToPage("/Authentication/AccessDenied");
            }

            // Get data
            User = HttpContext.Session.GetObject<User>(SessionKeyUserObject);

            Customer = await _customerService.GetCustomerByIdAsync(id);
            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var response = await _customerService.DeleteCustomerAsync(Customer.CustomerId);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/pcustomer/CustomerDetail");
            }

            ModelState.AddModelError(string.Empty, "An error occurred while deleting the customer.");
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
