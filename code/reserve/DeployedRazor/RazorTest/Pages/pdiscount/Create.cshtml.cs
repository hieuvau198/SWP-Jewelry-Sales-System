using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using System.Threading.Tasks;

namespace RazorTest.Pages.pdiscount
{
    public class CreateModel : PageModel
    {
        private readonly ApiService _apiService;
        private readonly DiscountService _discountService;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(ApiService apiService, DiscountService discountService, ILogger<CreateModel> logger)
        {
            _apiService = apiService;
            _discountService = discountService;
            _logger = logger;
        }

        [BindProperty]
        public Discount Discount { get; set; }

        public IActionResult OnGet()
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

            // Initialize the Discount with a new ID
            Discount = new Discount
            {
                DiscountId = Guid.NewGuid().ToString()
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

            // Check if DiscountId is still empty and generate it
            if (string.IsNullOrEmpty(Discount.DiscountId))
            {
                Discount.DiscountId = Guid.NewGuid().ToString();
            }

            var response = await _discountService.CreateDiscountAsync(Discount);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/pdiscount/DiscountDetail");
            }

            ModelState.AddModelError(string.Empty, "An error occurred while creating the discount.");
            _logger.LogError($"Failed to create discount. Status Code: {response.StatusCode}");
            return Page();
        }
    }
}
