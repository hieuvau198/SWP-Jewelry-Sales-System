using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Pages.pdiscount
{
    public class DiscountListModel : PageModel
    {
        private readonly ApiService _apiService;

        public DiscountListModel(ApiService apiService)
        {
            _apiService = apiService;
        }

       // public List<Discount> Discounts { get; set; }
        public PaginatedList<Discount> Discounts { get; set; }

        private const int PageSize = 10;
 
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

            // Get data
                var discounts = await _apiService.GetAsync<List<Discount>>("https://hvjewel.azurewebsites.net/api/discount");

                if (discounts != null)
                {
                    Discounts = PaginatedList<Discount>.Create(discounts.AsQueryable(), currentPage, 10);
                }

            return Page();
        }
    }
}