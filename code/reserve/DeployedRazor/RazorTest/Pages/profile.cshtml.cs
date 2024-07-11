using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;

namespace RazorTest.Pages
{
    public class profileModel : PageModel
    {
        public const string SessionKeyAuthState = "_AuthState";
        public const string SessionKeyUserObject = "_UserObject";

        private readonly ApiService _apiService;
        
        public profileModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public User User { get; set; }

        public async Task<IActionResult> OnGet()
        {

            try
            {
                // Verify Auth
                List<string> roles = new List<string> { "Admin", "Manager", "Sale", "Cashier" };
                if (!_apiService.VerifyAuth(HttpContext, roles))
                {
                    return RedirectToPage("/Authentication/Accessdenied");
                }

                // Process data
                User = HttpContext.Session.GetObject<User>(SessionKeyUserObject);
                
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error");
            }
            return Page();
        }
    }
}
