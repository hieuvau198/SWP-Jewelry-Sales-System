using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;
using System.Threading.Tasks;

namespace RazorTest.Pages.pgemstone
{
    public class DeleteModel : PageModel
    {
        public const string SessionKeyUserObject = "_UserObject";
        private readonly GemService _gemService;
        private readonly ApiService _apiService;

        public DeleteModel(GemService gemService, ApiService apiService)
        {
            _gemService = gemService;
            _apiService = apiService;
        }
        public User User { get; set; }

        [BindProperty]
        public Gem Gem { get; set; }

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
            // Process data
            User = HttpContext.Session.GetObject<User>(SessionKeyUserObject);
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
