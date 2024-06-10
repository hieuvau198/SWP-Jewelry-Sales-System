using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using System.Threading.Tasks;

namespace RazorTest.Pages.DiscountCRUD
{
    public class CreateModel : PageModel
    {
        private readonly ApiService _apiService;

        public CreateModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        [BindProperty]
        public Discount Discount { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var response = await _apiService.CreateDiscountAsync(Discount);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Discount/Index");
            }

            ModelState.AddModelError(string.Empty, "An error occurred while creating the discount.");
            return Page();
        }
    }
}
