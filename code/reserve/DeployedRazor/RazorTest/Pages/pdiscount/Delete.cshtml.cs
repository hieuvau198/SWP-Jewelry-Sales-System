using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using System.Threading.Tasks;

namespace RazorTest.Pages.pdiscount
{
    public class DeleteModel : PageModel
    {
        private readonly DiscountService _discountService;
        private readonly ApiService _apiService;
        public DeleteModel(DiscountService discountService, ApiService apiService)
        {
            _discountService = discountService;
            _apiService = apiService;
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

            // Get data
            Discount = await _discountService.GetDiscountByIdAsync(id);
            if (Discount == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var response = await _discountService.DeleteDiscountAsync(Discount.DiscountId);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/pdiscount/DiscountDetail");
            }

            ModelState.AddModelError(string.Empty, "An error occurred while deleting the discount.");
            return Page();
        }
    }
}
