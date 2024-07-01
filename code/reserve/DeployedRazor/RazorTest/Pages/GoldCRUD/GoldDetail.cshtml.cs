using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Pages.GoldCRUD
{
    public class GoldListModel : PageModel
    {
        private readonly ApiService _apiService;

        public GoldListModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public List<Gold> Golds { get; set; }

        public async Task OnGetAsync()
        {
            var golds = await _apiService.GetAsync<List<Gold>>("https://jewelsystembe20240701213216.azurewebsites.net/api/gold");

            if (golds != null)
            {
                Golds = golds.OrderBy(b => b.GoldId).ToList();
            }
        }
    }
}
