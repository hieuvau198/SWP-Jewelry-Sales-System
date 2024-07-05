using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Services;
using RazorTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RazorTest.Utilities;

namespace RazorTest.Pages.pdiscount
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
            // Process data
            User = HttpContext.Session.GetObject<User>(SessionKeyUserObject);
            var discounts = await _apiService.GetAsync<List<Discount>>("https://hvjewel.azurewebsites.net/api/discount");

            return Page();
        }
    }
}
