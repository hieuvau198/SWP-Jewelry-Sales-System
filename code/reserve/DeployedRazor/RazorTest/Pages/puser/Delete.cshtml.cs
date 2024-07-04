using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using System.Threading.Tasks;

namespace RazorTest.Pages.puser
{
    public class DeleteModel : PageModel
    {
        private readonly UserService _userService;
        private readonly ApiService _apiService;

        public DeleteModel(UserService userService, ApiService apiService)
        {
            _userService = userService;
            _apiService = apiService;
        }

        [BindProperty]
        public User User { get; set; }

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

            User = await _userService.GetUserByIdAsync(id);
            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var response = await _userService.DeleteUserAsync(User.UserId);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/puser/UserDetail");
            }

            ModelState.AddModelError(string.Empty, "An error occurred while deleting the user.");
            return Page();
        }
    }
}
