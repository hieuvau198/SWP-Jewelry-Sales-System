using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Pages.UserCRUD
{
    public class IndexModel : PageModel
    {
        private readonly ApiService _apiService;

        public  IndexModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public List<User> Users { get; set; }

        public async Task OnGetAsync()
        {
            var users = await _apiService.GetAsync<List<User>>("http://localhost:5071/api/user");

            if (users != null)
            {
                Users = users.OrderBy(u => u.UserId).ToList();
            }
        }
    }
}
