using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using System.Threading.Tasks;

namespace RazorTest.Pages.DiscountCRUD
{
    public class DeleteModel : PageModel
    {
        private readonly ApiService _apiService;

        public DeleteModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        [BindProperty]
        public Discount Discount { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Discount = await _apiService.GetDiscountByIdAsync(id);
            if (Discount == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var response = await _apiService.DeleteDiscountAsync(Discount.DiscountId);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Discount/Index");
            }

            ModelState.AddModelError(string.Empty, "An error occurred while deleting the discount.");
            return Page();
        }
    }
}
