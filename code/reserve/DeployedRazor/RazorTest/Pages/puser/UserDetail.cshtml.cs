using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Pages.puser
{
    public class UserListModel : PageModel
    {
        public const string SessionKeyUserObject = "_UserObject";
        private readonly ApiService _apiService;

        public UserListModel(ApiService apiService)
        {
            _apiService = apiService;
        }
        public User User { get; set; }

        //  public List<User> Users { get; set; }

        public PaginatedList<User> Users { get; set; }

        public const int PageSize = 6;
        public async Task<IActionResult> OnGetAsync(int currentPage = 1)
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
            // Process data
            User = HttpContext.Session.GetObject<User>(SessionKeyUserObject);

            var users = await _apiService.GetAsync<List<User>>("https://hvjewel.azurewebsites.net/api/user");
            users = users.OrderByDescending(x => x.UserId).ToList();

            if (users != null)
            {
                Users = PaginatedList<User>.Create(users.AsQueryable(), currentPage, 6);

            }

            return Page();
        }
    }
}
