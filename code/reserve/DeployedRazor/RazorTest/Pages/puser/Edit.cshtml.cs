using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;
using System.Threading.Tasks;

namespace RazorTest.Pages.puser
{
    public class EditModel : PageModel
    {
        public const string SessionKeyUserObject = "_UserObject";
        public const string SessionKeyAuthState = "_AuthState";
        private readonly UserService _userService;
        private readonly ApiService _apiService;
        private readonly ILogger<EditModel> _logger;
        public EditModel(ApiService apiService, ILogger<EditModel> logger, UserService userService)
        {
            _userService = userService;
            _logger = logger;
        }
        public User User { get; set; }

        [BindProperty]
        public User Usern { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
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
            // Process data
            User = HttpContext.Session.GetObject<User>(SessionKeyUserObject);

            if (id == null)
            {
                _logger.LogError("ID is null");
                return NotFound();
            }

            Usern = await _userService.GetUserByIdAsync(id);

            if (Usern == null)
            {
                _logger.LogError($"User not found for ID {id}");
                return NotFound();
            }
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

            _logger.LogInformation($"Updating user with ID {User.UserId}");
            _logger.LogInformation($"User details: {JsonConvert.SerializeObject(Usern)}");

            var response = await _userService.UpdateUserAsync(Usern);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"Failed to update user. Status Code: {response.StatusCode}");
                ModelState.AddModelError(string.Empty, "An error occurred while updating the user.");
                return Page();
            }

            _logger.LogInformation("Successfully updated user");
            return RedirectToPage("./UserDetail");
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
