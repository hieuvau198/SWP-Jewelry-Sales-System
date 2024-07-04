using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Pages.puser
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
            var users = await _apiService.GetAsync<List<User>>("https://hvjewel.azurewebsites.net/api/user");

            if (users != null)
            {
                Users = users.OrderBy(u => u.UserId).ToList();
            }
        }
    }
}
