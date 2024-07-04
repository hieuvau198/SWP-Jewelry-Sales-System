using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RazorTest.Models;
using RazorTest.Services;
using System.Threading.Tasks;

namespace RazorTest.Pages.puser
{
    public class EditModel : PageModel
    {
        private readonly UserService _userService;
        private readonly ApiService _apiService;
        private readonly ILogger<EditModel> _logger;
        public EditModel(ApiService apiService, ILogger<EditModel> logger, UserService userService)
        {
            _userService = userService;
            _logger = logger;
        }

        [BindProperty]
        public User User { get; set; }

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

            if (id == null)
            {
                _logger.LogError("ID is null");
                return NotFound();
            }

            User = await _userService.GetUserByIdAsync(id);

            if (User == null)
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
            _logger.LogInformation($"User details: {JsonConvert.SerializeObject(User)}");

            var response = await _userService.UpdateUserAsync(User);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"Failed to update user. Status Code: {response.StatusCode}");
                ModelState.AddModelError(string.Empty, "An error occurred while updating the user.");
                return Page();
            }

            _logger.LogInformation("Successfully updated user");
            return RedirectToPage("./UserDetail");
        }
    }
}
