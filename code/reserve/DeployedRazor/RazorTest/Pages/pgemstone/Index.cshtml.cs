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
    public class IndexModel : PageModel
    {
        public const string SessionKeyUserObject = "_UserObject";
        private readonly ApiService _apiService;

        public IndexModel(ApiService apiService)
        {
            _apiService = apiService;
        }
        public User User { get; set; }

        public List<Gem> Gems { get; set; }
        public PaginatedList<Gem> GemsP { get; set; }

        private const int PageSize = 10;
        public string SearchTerm { get; set; }
        public string FilterType { get; set; } = "All";

        public async Task<IActionResult> OnGetAsync(string searchTerm, string filterType, int currentPage = 1)
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
            if(gems == null)
            {
                return RedirectToPage("/Error");
            }

            

            if(filterType != null && !filterType.Equals("All"))
            {
                FilterType = filterType;
                gems = gems.Where(x => (x.GemName.Contains(FilterType))).ToList();
            }
            else
            {
                FilterType = "All";
            }

            if (searchTerm != null)
            {
                SearchTerm = searchTerm;
                gems = gems.Where(x => (x.GemName.Contains(SearchTerm))).ToList();
            }
            else
            {
                SearchTerm = string.Empty;
            }

            Gems = gems.ToList();

            GemsP = PaginatedList<Gem>.Create(gems.AsQueryable(), currentPage, PageSize);

            return Page();
        }
    }
}
