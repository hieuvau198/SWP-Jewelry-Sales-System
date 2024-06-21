using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorTest.Pages.Authentication
{
    public class LogoutPageModel : PageModel
    {
        public const string SessionKeyUserObject = "_UserObject";
        public const string SessionKeyAuthState = "_AuthState";
        
        public IActionResult OnGet()
        {
            // Clear authentication session variable
            HttpContext.Session.Remove(SessionKeyUserObject);
            HttpContext.Session.Remove(SessionKeyAuthState);
            HttpContext.Session.Clear();

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
