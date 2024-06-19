using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Pages.GemCRUD
{
    public class IndexModel : PageModel
    {
        private readonly ApiService _apiService;

        public IndexModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public List<Gem> Gems { get; set; }

        public async Task OnGetAsync()
        {
            var gems = await _apiService.GetAsync<List<Gem>>("http://localhost:5071/api/gem");
        }
    }
}
