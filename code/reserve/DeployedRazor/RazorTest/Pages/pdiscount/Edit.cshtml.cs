using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RazorTest.Models;
using RazorTest.Services;
using System.Threading.Tasks;

namespace RazorTest.Pages.pdiscount
{
    public class EditModel : PageModel
    {
        private readonly DiscountService _discountService;
        private readonly ApiService _apiService;
        private readonly ILogger<EditModel> _logger;
        public EditModel(ApiService apiService, ILogger<EditModel> logger, DiscountService discountService)
        {
            _discountService = discountService;
            _apiService = apiService;
            _logger = logger;   
        }

        [BindProperty]
        public Discount Discount { get; set; }

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

            if (id == null)
            {
                _logger.LogError("ID is null");
                return NotFound();
            }

            Discount = await _discountService.GetDiscountByIdAsync(id);

            if (Discount == null)
            {
                _logger.LogError($"Discount not found for ID {id}");
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

            _logger.LogInformation($"Updating discount with ID {Discount.DiscountId}");
            _logger.LogInformation($"Discount details: {JsonConvert.SerializeObject(Discount)}");

            var response = await _discountService.UpdateDiscountAsync(Discount);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"Failed to update discount. Status Code: {response.StatusCode}");
                ModelState.AddModelError(string.Empty, "An error occurred while updating the discount.");
                return Page();
            }

            _logger.LogInformation("Successfully updated discount");
            return RedirectToPage("./DiscountDetail");
        }
    }
    }
