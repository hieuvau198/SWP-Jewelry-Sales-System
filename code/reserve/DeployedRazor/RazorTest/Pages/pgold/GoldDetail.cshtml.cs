using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Pages.pgold
{
    public class GoldListModel : PageModel
    {
        public const string SessionKeyUserObject = "_UserObject";
        public const string SessionKeyAuthState = "_AuthState";
        private readonly ApiService _apiService;

        public GoldListModel(ApiService apiService)
        {
            _apiService = apiService;
        }
        public User User { get; set; }

        public List<Gold> Golds { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Verify auth
                List<string> roles = new List<string>
                        {
                            "Manager",
                            "Cashier",
                            "Sale",
                            "Admin"
                        };
                if (!_apiService.VerifyAuth(HttpContext, roles))
                {
                    return RedirectToPage("/Authentication/AccessDenied");
                }
            // Process data
            User = HttpContext.Session.GetObject<User>(SessionKeyUserObject);
            var golds = await _apiService.GetAsync<List<Gold>>("http://localhost:5071/api/gold");

            if (golds != null)
            {
                Golds = golds.OrderBy(b => b.GoldId).ToList();
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
