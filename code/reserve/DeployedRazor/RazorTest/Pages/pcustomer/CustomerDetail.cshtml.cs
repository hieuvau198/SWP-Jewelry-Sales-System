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
        private readonly ApiService _apiService;

        public CustomerListModel(ApiService apiService)
        {
            _apiService = apiService;
        }

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
            var customers = await _apiService.GetAsync<List<Customer>>("https://hvjewel.azurewebsites.net/api/customer");

            // Separate pages
            if (customers != null)
            {
                Customers = PaginatedList<Customer>.Create(customers.AsQueryable(), currentPage, 3);

            }

            return Page();
        }

    }
}
