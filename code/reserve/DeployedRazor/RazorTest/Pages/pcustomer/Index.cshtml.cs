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
    public class IndexModel : PageModel
    {
        public const string SessionKeyUserObject = "_UserObject";
        
        private readonly ApiService _apiService;

        public IndexModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public User User { get; set; }

        public List<Customer> Customers { get; set; }

        public async Task<IActionResult> OnGetAsync()
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
            var customers = await _apiService.GetAsync<List<Customer>>("https://hvjewel.azurewebsites.net/api/customer");

            if (customers != null)
            {
                Customers = customers.OrderBy(c => c.CustomerId).ToList();
            }

            return Page();
        }
    }
}
