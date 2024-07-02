using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using System.Threading.Tasks;

namespace RazorTest.Pages.pgemstone
{
    public class DeleteModel : PageModel
    {
        private readonly GemService _gemService;

        public DeleteModel(GemService gemService)
        {
            _gemService = gemService;
        }

        [BindProperty]
        public Gem Gem { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Gem = await _gemService.GetGemByIdAsync(id);
            if (Gem == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var response = await _gemService.DeleteGemAsync(Gem.GemId);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/pgemstone/Detail");
            }

            ModelState.AddModelError(string.Empty, "An error occurred while deleting the gem.");
            return Page();
        }
    }
}
