using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using System.Threading.Tasks;

namespace RazorTest.Pages.pwarranty
{
    public class CreateModel : PageModel
    {
        private readonly WarrantyService _warrantyService;
        private readonly ApiService _apiService;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(WarrantyService warrantyService, ILogger<CreateModel> logger, ApiService apiService)
        {
            _warrantyService = warrantyService;
            _logger = logger;
            _apiService = apiService;
        }

        [BindProperty]
        public Warranty Warranty { get; set; }

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

            // Initialize the Discount with a new ID
            Warranty = new Warranty
            {
                WarrantyId = Guid.NewGuid().ToString()
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

            // Check if WarrantyId is still empty and generate it
            if (string.IsNullOrEmpty(Warranty.WarrantyId))
            {
                Warranty.WarrantyId = Guid.NewGuid().ToString();
            }

            var response = await _warrantyService.CreateWarrantyAsync(Warranty);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/pwarranty/WarrantyDetail");
            }

            ModelState.AddModelError(string.Empty, "An error occurred while creating the warranty.");
            _logger.LogError($"Failed to create warranty. Status Code: {response.StatusCode}");
            return Page();
        }
    }
}
