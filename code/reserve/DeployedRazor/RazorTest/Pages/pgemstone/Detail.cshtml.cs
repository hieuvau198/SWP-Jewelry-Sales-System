using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Pages.pgemstone
{
    public class GemListModel : PageModel
    {
        public const string SessionKeyUserObject = "_UserObject";
        public const string SessionKeyAuthState = "_AuthState";
        private readonly ApiService _apiService;

        public GemListModel(ApiService apiService)
        {
            _apiService = apiService;
        }
        public User User { get; set; }

        //      public List<Gem> Gems { get; set; }

        public PaginatedList<Gem> Gems { get; set; }

        private const int PageSize = 15;

        public async Task<IActionResult> OnGetAsync(int currentPage = 1)
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
            var gems = await _apiService.GetAsync<List<Gem>>("https://hvjewel.azurewebsites.net/api/gem");

            if (gems != null)
            {
                Gems = PaginatedList<Gem>.Create(gems.AsQueryable(), currentPage, 15);

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
