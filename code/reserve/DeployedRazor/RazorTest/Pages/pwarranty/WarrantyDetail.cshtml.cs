using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Pages.pwarranty
{
    public class WarrantyListModel : PageModel
    {
        private readonly ApiService _apiService;

        public WarrantyListModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public List<Warranty> Warranties { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Verify auth
            List<string> roles = new List<string>
            {
                "Sale",
                "Cashier",
                "Manager",
                "Admin"
            };
            if (!_apiService.VerifyAuth(HttpContext, roles))
            {
                return RedirectToPage("/Authentication/AccessDenied");
            }

            var warranties = await _apiService.GetAsync<List<Warranty>>("https://hvjewel.azurewebsites.net/api/warranty");

            if (warranties != null)
            {
                Warranties = warranties.OrderBy(w => w.WarrantyId).ToList();
            }

            return Page();
        }
    }
}
