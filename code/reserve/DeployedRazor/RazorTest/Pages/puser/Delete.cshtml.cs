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

        public DeleteModel(UserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
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
