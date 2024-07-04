using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using System.Threading.Tasks;

namespace RazorTest.Pages.puser
{
    public class CreateModel : PageModel
    {
        private readonly UserService _userService;
        private readonly ApiService _apiService;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(UserService userService, ILogger<CreateModel> logger, ApiService apiService)
        {
            _userService = userService;
            _logger = logger;
            _apiService = apiService;
        }

        [BindProperty]
        public User User { get; set; }

        public IActionResult OnGet()
        {
            // Verify auth
            List<string> roles = new List<string>
            {
                "Admin"
            };
            if (!_apiService.VerifyAuth(HttpContext, roles))
            {
                return RedirectToPage("/Authentication/AccessDenied");
            }

            // Initialize the Create with a new ID
            User = new User
            {
                UserId = Guid.NewGuid().ToString()
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {   
            if (!ModelState.IsValid)
            {
                foreach (var modelStateKey in ModelState.Keys)
                {
                    var modelStateVal = ModelState[modelStateKey];
                    foreach (var error in modelStateVal.Errors)
                    {
                        _logger.LogError($"Key: {modelStateKey}, Error: {error.ErrorMessage}");
                    }
                }

                return Page();
            }

            // Check if UserId is still empty and generate it
            if (string.IsNullOrEmpty(User.UserId))
            {
                User.UserId = Guid.NewGuid().ToString();
            }

            var response = await _userService.CreateUserAsync(User);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/puser/UserDetail");
            }

            ModelState.AddModelError(string.Empty, "An error occurred while creating the user.");
            _logger.LogError($"Failed to create user. Status Code: {response.StatusCode}");
            return Page();
        }
    }
}
