using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Pages.pwarranty
{
    public class WarrantyListModel : PageModel
    {
        public const string SessionKeyUserObject = "_UserObject";
        private readonly ApiService _apiService;

        public WarrantyListModel(ApiService apiService)
        {
            _apiService = apiService;
        }
        public User User { get; set; }

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
            // Process data
            User = HttpContext.Session.GetObject<User>(SessionKeyUserObject);

            var warranties = await _apiService.GetAsync<List<Warranty>>("http://localhost:5071/api/warranty");

            if (warranties != null)
            {
                Warranties = warranties.OrderBy(w => w.WarrantyId).ToList();
            }

            return Page();
        }
    }
}
