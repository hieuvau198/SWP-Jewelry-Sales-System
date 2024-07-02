using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using System.Threading.Tasks;

namespace RazorTest.Pages.pgold
{
    public class DeleteModel : PageModel
    {
        private readonly GoldService _goldService;

        public DeleteModel(GoldService goldService)
        {
            _goldService = goldService;
        }

        [BindProperty]
        public Gold Gold { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Gold = await _goldService.GetGoldByIdAsync(id);
            if (Gold == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var response = await _goldService.DeleteGoldAsync(Gold.GoldId);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/pgold/GoldDetail");
            }

            ModelState.AddModelError(string.Empty, "An error occurred while deleting the gold.");
            return Page();
        }
    }
}
