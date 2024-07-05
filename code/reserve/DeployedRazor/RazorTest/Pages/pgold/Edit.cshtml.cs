using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;
using System.Threading.Tasks;

namespace RazorTest.Pages.pgold
{
    public class EditModel : PageModel
    {
        public const string SessionKeyUserObject = "_UserObject";
        private readonly GoldService _goldService;
        private readonly ApiService _apiService;
        private readonly ILogger<EditModel> _logger;
        public EditModel(ApiService apiService, ILogger<EditModel> logger, GoldService goldService)
        {
            _goldService = goldService;
            _apiService = apiService;
            _logger = logger;
        }
        public User User { get; set; }

        [BindProperty]
        public Gold Gold { get; set; }

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

            Gold = await _goldService.GetGoldByIdAsync(id);

            if (Gold == null)
            {
                _logger.LogError($"Gold not found for ID {id}");
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

            _logger.LogInformation($"Updating gold with ID {Gold.GoldId}");
            _logger.LogInformation($"Gold details: {JsonConvert.SerializeObject(Gold)}");

            var response = await _goldService.UpdateGoldAsync(Gold);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"Failed to update gold. Status Code: {response.StatusCode}");
                ModelState.AddModelError(string.Empty, "An error occurred while updating the gold.");
                return Page();
            }

            _logger.LogInformation("Successfully updated gold");
            return RedirectToPage("./GoldDetail");
        }
    }
}
