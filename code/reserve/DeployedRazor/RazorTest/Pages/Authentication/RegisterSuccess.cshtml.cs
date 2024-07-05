using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Services;

namespace RazorTest.Pages.Authentication
{
    public class RegisterSuccessModel : PageModel
    {
        private readonly ApiService _apiService;

        public IActionResult OnGet()
        {
            List<string> roles = new List<string>
                {
                    "Admin",
                    "Manager",
                    "Sale",
                    "Cashier"
                };
            if (_apiService.VerifyAuth(HttpContext, roles))
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }
    }
}
