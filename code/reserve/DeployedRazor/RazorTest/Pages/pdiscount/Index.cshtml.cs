using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Services;
using RazorTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RazorTest.Pages.pdiscount
{
    public class IndexModel : PageModel
    {
        private readonly ApiService _apiService;

        public IndexModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public List<Discount> Discounts { get; set; }

        public async Task<IActionResult> OnGetAsync()
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

            var discounts = await _apiService.GetAsync<List<Discount>>("https://hvjewel.azurewebsites.net/api/discount");

            return Page();
        }
    }
}
