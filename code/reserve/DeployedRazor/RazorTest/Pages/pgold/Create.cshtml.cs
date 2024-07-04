using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using System.Threading.Tasks;

namespace RazorTest.Pages.pgold
{
    public class CreateModel : PageModel
    {
        private readonly GoldService _goldService;
        private readonly ApiService _apiService;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(GoldService goldService, ILogger<CreateModel> logger, ApiService apiService)
        {
            _goldService = goldService;
            _logger = logger;
            _apiService = apiService;
        }

        [BindProperty]
        public Gold Gold { get; set; }

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

            // Initialize the Gold with a new ID
            Gold = new Gold
            {
                GoldId = Guid.NewGuid().ToString()
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

            // Check if GoldID is still empty and generate it
            if (string.IsNullOrEmpty(Gold.GoldId))
            {
                Gold.GoldId = Guid.NewGuid().ToString();
            }

            var response = await _goldService.CreateGoldAsync(Gold);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/pgold/GoldDetail");
            }

            ModelState.AddModelError(string.Empty, "An error occurred while creating the gold.");
            _logger.LogError($"Failed to create gold. Status Code: {response.StatusCode}");
            return Page();
        }
    }
}
