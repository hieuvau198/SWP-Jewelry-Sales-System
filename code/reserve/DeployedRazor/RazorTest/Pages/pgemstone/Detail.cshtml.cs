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

        private const int PageSize = 10;

        public string SearchTerm { get; set; }
        public string FilterUnit { get; set; } = "All";

        public async Task<IActionResult> OnGetAsync(string searchTerm, string filterUnit, int currentPage = 1)
        {
            try
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
                if (gems == null)
                {
                    return RedirectToPage("/Error");
                }

                // Set search and filter parameters
                SearchTerm = searchTerm;
                FilterUnit = !string.IsNullOrEmpty(filterUnit) ? filterUnit : "All";

                // Filter gems based on unit
                if (!string.IsNullOrEmpty(filterUnit) && !filterUnit.Equals("All"))
                {
                    gems = gems.Where(g => g.Unit != null && g.Unit.Contains(filterUnit)).ToList();
                }

                // Search gems based on searchTerm
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    gems = gems.Where(g =>
                        (g.GemName != null && g.GemName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
                        (g.GemCode != null && g.GemCode.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
                        (g.Unit != null && g.Unit.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    ).ToList();
                }

                // Separate pages
                if (gems != null)
                {
                    Gems = PaginatedList<Gem>.Create(gems.AsQueryable(), currentPage, PageSize);
                }
                
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error");
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
