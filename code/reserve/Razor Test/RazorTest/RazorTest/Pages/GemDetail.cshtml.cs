using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Pages
{
    public class GemListModel : PageModel
    {
        private readonly ApiService _apiService;

        public GemListModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public List<Gem> Gems { get; set; }

        public async Task OnGetAsync()
        {
            var gems = await _apiService.GetAsync<List<Gem>>("http://localhost:5156/api/gem");

            if (gems != null)
            {
                Gems = gems.OrderBy(g => g.GemId).ToList();
            }
        }
    }
}
