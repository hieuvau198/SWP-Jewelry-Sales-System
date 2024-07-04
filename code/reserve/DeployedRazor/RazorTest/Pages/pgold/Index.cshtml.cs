using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Pages.pgold
{
    public class IndexModel : PageModel
    {
        private readonly ApiService _apiService;

        public IndexModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public List<Gold> Golds { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Verify auth
                List<string> roles = new List<string>
                        {
                            "Manager",
                            "Admin"
                        };
                if (!_apiService.VerifyAuth(HttpContext, roles))
                {
                    return RedirectToPage("/Authentication/AccessDenied");
                }

            var golds = await _apiService.GetAsync<List<Gold>>("https://hvjewel.azurewebsites.net/api/gold");

            return Page();
        }
    }
}
