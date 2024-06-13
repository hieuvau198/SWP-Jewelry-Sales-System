using JewelSystemBE;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Pages
{
    public class GoldPriceListModel : PageModel
    {
        private readonly ApiService _apiService;

        public GoldPriceListModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public List<GoldPrice> GoldPrices { get; set; }

        public async Task OnGetAsync()
        {
            var goldprices = await _apiService.GetAsync<List<GoldPrice>>("http://localhost:5071/api/goldprice");

            if (goldprices != null)
            {
                GoldPrices = goldprices.OrderBy(c => c.Name).ToList();
            }
        }

    }
}
