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
    public class IndexModel : PageModel
    {
        public const string SessionKeyUserObject = "_UserObject";
        
        private readonly ApiService _apiService;

        public  IndexModel(ApiService apiService)
        {
            _apiService = apiService;
        }
        public User User { get; set; }

        //  public List<User> Users { get; set; }

        public PaginatedList<User> Users { get; set; }

        public const int PageSize = 6;

        public string SearchTerm { get; set; }
        public string FilterRole { get; set; } = "All";

        public async Task<IActionResult> OnGetAsync(string searchTerm, string filterRole, int currentPage = 1)
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

            // Set search and filter parameters
            SearchTerm = searchTerm;
            FilterRole = !string.IsNullOrEmpty(filterRole) ? filterRole : "All";

            // Filter users based on role
            if (!string.IsNullOrEmpty(filterRole) && !filterRole.Equals("All"))
            {
                users = users.Where(u => u.Role != null && u.Role.Contains(filterRole)).ToList();
            }

            // Search users based on searchTerm
            if (!string.IsNullOrEmpty(searchTerm))
            {
                users = users.Where(u =>
                    (u.Fullname != null && u.Fullname.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
                    (u.Email != null && u.Email.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
                    (u.Role != null && u.Role.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                ).ToList();
            }

            // Separate pages
            if (users != null)
            {
                Users = PaginatedList<User>.Create(users.AsQueryable(), currentPage, PageSize);
            }

            return Page();
        }
    }
}
