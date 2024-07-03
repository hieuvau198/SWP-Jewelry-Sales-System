using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Pages.Sale;
using RazorTest.Services;
using RazorTest.Utilities;

namespace RazorTest.Pages.Authentication
{
    public class LoginPageModel : PageModel
    {
        public const string SessionKeyUserObject = "_UserObject";
        public const string SessionKeyAuthState = "_AuthState";

        public const string UrlLogin = "http://localhost:5071/api/auth/login\r\n";

        private readonly ApiService _apiService;
        private readonly ILogger<SaleHomePageModel> _logger;
        public LoginPageModel(ApiService apiService, ILogger<SaleHomePageModel> logger)
        {
            _apiService = apiService;
            _logger = logger;
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                User loginDto = new User
                {
                    Username = Username,
                    Password = Password
                };
                User user = await _apiService.PostAsJsonAndDeserializeAsync<User>(UrlLogin, loginDto);
                if (user != null && user.Role != null)
                {
                    HttpContext.Session.SetObject(SessionKeyUserObject, user);
                    HttpContext.Session.SetObject(SessionKeyAuthState, true);

                    // Set the ViewData["Username"] with the logged-in username
                    ViewData["Username"] = user.Username;

                    return RedirectToPage("/Index");
                }

                HttpContext.Session.SetObject(SessionKeyAuthState, false);
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
            }

            return Page();
        }
    }
}
