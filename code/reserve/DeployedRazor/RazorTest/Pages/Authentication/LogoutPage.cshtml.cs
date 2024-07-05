using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Services;

namespace RazorTest.Pages.Authentication
{
    public class LogoutPageModel : PageModel
    {
        public const string SessionKeyUserObject = "_UserObject";
        public const string SessionKeyAuthState = "_AuthState";

        private readonly ApiService _apiService;

        public LogoutPageModel(ApiService apiService)
        {
            _apiService = apiService;
        }
        public IActionResult OnGet()
        {
            try
            {
                // Verify access
                List<string> roles = new List<string>
                {
                    "Admin",
                    "Manager",
                    "Sale",
                    "Cashier"
                };
                if (!_apiService.VerifyAuth(HttpContext, roles))
                {
                    return RedirectToPage("/NotFound");
                }

                // Clear authentication session variable
                HttpContext.Session.Remove(SessionKeyUserObject);
                HttpContext.Session.Remove(SessionKeyAuthState);
                HttpContext.Session.Clear();
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error");
            }

            // Redirect to login page or any other page
            return RedirectToPage("/Index");
        }

        public IActionResult OnPost()
        {
            // Perform the same action as OnGet() for logout button click
            return OnGet();
        }
    }
}
