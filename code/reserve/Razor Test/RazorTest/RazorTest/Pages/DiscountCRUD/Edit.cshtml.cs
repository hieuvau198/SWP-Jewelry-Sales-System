using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using System.Threading.Tasks;

namespace RazorTest.Pages.DiscountCRUD
{
    public class EditModel : PageModel
    {
        private readonly ApiService _apiService;

        public EditModel(ApiService apiService)
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var response = await _apiService.UpdateDiscountAsync(Discount);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Discount/Index");
            }

            ModelState.AddModelError(string.Empty, "An error occurred while updating the discount.");
            return Page();
        }
    }
}
