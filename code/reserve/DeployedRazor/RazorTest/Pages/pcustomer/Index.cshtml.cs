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
        public const string SessionKeyAuthState = "_AuthState";

        private readonly ApiService _apiService;

        public IndexModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public User User { get; set; }

        // public List<Customer> Customers { get; set; }

        public PaginatedList<Customer> Customers { get; set; }

        public const int PageSize = 3;

        public string SearchTerm { get; set; }
        public string FilterRank { get; set; } = "All";

        public async Task<IActionResult> OnGetAsync(string searchTerm, string filterRank, int currentPage = 1)
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

            var customers = await _apiService.GetAsync<List<Customer>>("http://localhost:5071/api/customer");


            // Set search and filter parameters
            SearchTerm = searchTerm;
            FilterRank = !string.IsNullOrEmpty(filterRank) ? filterRank : "All";

            // Filter customers based on rank
            if (!string.IsNullOrEmpty(filterRank) && !filterRank.Equals("All"))
            {
                customers = customers.Where(c => c.CustomerRank != null && c.CustomerRank.Contains(filterRank)).ToList();
            }

            // Search customers based on searchTerm
            if (!string.IsNullOrEmpty(searchTerm))
            {
                customers = customers.Where(c =>
                    (c.CustomerId.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
                    (c.CustomerName != null && c.CustomerName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
                    (c.CustomerRank != null && c.CustomerRank.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
                    (c.CustomerPoint.ToString().Contains(searchTerm)) ||
                    (c.AttendDate.ToString().Contains(searchTerm))
                ).ToList();
            }

            // Separate pages
            if (customers != null)
            {
                Customers = PaginatedList<Customer>.Create(customers.AsQueryable(), currentPage, 3);

            }

            return Page();
        }
    }
}
