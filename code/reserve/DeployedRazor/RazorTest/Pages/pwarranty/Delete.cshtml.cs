using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using System.Threading.Tasks;

namespace RazorTest.Pages.pwarranty
{
    public class DeleteModel : PageModel
    {
        private readonly WarrantyService _warrantyService;
        private readonly ApiService _apiService;

        public DeleteModel(WarrantyService warrantyService, ApiService apiService)
        {
            _warrantyService = warrantyService;
            _apiService = apiService;
        }

        [BindProperty]
        public Warranty Warranty { get; set; }

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

            Warranty = await _warrantyService.GetWarrantyByIdAsync(id);
            if (Warranty == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var response = await _warrantyService.DeleteWarrantyAsync(Warranty.WarrantyId);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/pwarranty/WarrantyDetail");
            }

            ModelState.AddModelError(string.Empty, "An error occurred while deleting the warranty.");
            return Page();
        }
    }
}
