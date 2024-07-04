using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Pages.pgemstone
{
    public class GemListModel : PageModel
    {
        private readonly ApiService _apiService;

        public GemListModel(ApiService apiService)
        {
            _apiService = apiService;
        }

  //      public List<Gem> Gems { get; set; }

        public PaginatedList<Gem> Gems { get; set; }

        private const int PageSize = 15;

        public async Task OnGetAsync(int currentPage = 1)
        {
            var gems = await _apiService.GetAsync<List<Gem>>("https://hvjewel.azurewebsites.net/api/gem");

            if (gems != null)
            {
                Gems = PaginatedList<Gem>.Create(gems.AsQueryable(), currentPage, 15);

            }
        }
    }
}
