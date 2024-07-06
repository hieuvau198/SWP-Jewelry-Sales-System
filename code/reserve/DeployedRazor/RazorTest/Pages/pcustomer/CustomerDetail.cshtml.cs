using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Pages.pcustomer
{
    public class CustomerListModel : PageModel
    {
        public const string SessionKeyUserObject = "_UserObject";
        public const string SessionKeyAuthState = "_AuthState";
        private readonly ApiService _apiService;

        public CustomerListModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public User User { get; set; }

        // public List<Customer> Customers { get; set; }

        public PaginatedList<Customer> Customers { get; set; }

        public const int PageSize = 3;

        public async Task<IActionResult> OnGetAsync(int currentPage = 1)
        {
            // Verify auth
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

            // get data
            User = HttpContext.Session.GetObject<User>(SessionKeyUserObject);

            var customers = await _apiService.GetAsync<List<Customer>>("https://hvjewel.azurewebsites.net/api/customer");

            // Separate pages
            if (customers != null)
            {
                Customers = PaginatedList<Customer>.Create(customers.AsQueryable(), currentPage, 3);

            }

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
