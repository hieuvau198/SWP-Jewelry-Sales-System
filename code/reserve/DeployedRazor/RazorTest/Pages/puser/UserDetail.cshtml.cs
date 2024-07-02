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
        private readonly ApiService _apiService;

        public UserListModel(ApiService apiService)
        {
            _apiService = apiService;
        }

      //  public List<User> Users { get; set; }

        public PaginatedList<User> Users { get; set; }

        public const int PageSize = 6;
        public async Task OnGetAsync(int currentPage = 1)
        {
            var users = await _apiService.GetAsync<List<User>>("https://jewelsystembe20240701213216.azurewebsites.net/api/user");

            if (users != null)
            {
                Users = PaginatedList<User>.Create(users.AsQueryable(), currentPage, 6);

            }
        }
    }
}
