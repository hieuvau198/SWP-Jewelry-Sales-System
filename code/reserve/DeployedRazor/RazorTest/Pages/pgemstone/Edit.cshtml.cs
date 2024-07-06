using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;
using System.Threading.Tasks;

namespace RazorTest.Pages.pgemstone
{
    public class EditModel : PageModel
    {
        public const string SessionKeyUserObject = "_UserObject";
        public const string SessionKeyAuthState = "_AuthState";
        private readonly GemService _gemService;
        private readonly ApiService _apiService;
        private readonly ILogger<EditModel> _logger;
        public EditModel(ApiService apiService, ILogger<EditModel> logger, GemService gemService)
        {
            _gemService = gemService;
            _apiService = apiService;
            _logger = logger;
        }
        public User User { get; set; }

        [BindProperty]
        public Gem Gem { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
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
            // Process data
            User = HttpContext.Session.GetObject<User>(SessionKeyUserObject);
            if (id == null)
            {
                _logger.LogError("ID is null");
                return NotFound();
            }

            Gem = await _gemService.GetGemByIdAsync(id);

            if (Gem == null)
            {
                _logger.LogError($"Gem not found for ID {id}");
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

            _logger.LogInformation($"Updating gem with ID {Gem.GemId}");
            _logger.LogInformation($"Gem details: {JsonConvert.SerializeObject(Gem)}");

            var response = await _gemService.UpdateGemAsync(Gem);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"Failed to update gem. Status Code: {response.StatusCode}");
                ModelState.AddModelError(string.Empty, "An error occurred while updating the gem.");
                return Page();
            }

            _logger.LogInformation("Successfully updated gem");
            return RedirectToPage("./Detail");
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
