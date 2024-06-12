using JewelBO;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Pages
{
    public class JewelListModel : PageModel
    {
        private readonly ApiService _apiService;

        public JewelListModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public List<Jewel> Jewels { get; set; }

        public async Task OnGetAsync()
        {
            var jewels = await _apiService.GetAsync<List<Jewel>>("http://localhost:5071/api/jewel");

            if (jewels != null)
            {
                Jewels = jewels.OrderBy(j => j.Id).ToList();
            }
        }
    }
}
