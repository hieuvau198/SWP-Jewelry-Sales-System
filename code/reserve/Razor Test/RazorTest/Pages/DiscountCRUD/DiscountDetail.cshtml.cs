using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Pages.DiscountCRUD
{
    public class DiscountListModel : PageModel
    {
        private readonly ApiService _apiService;

        public DiscountListModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public List<Discount> Discounts { get; set; }

        public async Task OnGetAsync()
        {
            var discounts = await _apiService.GetAsync<List<Discount>>("http://localhost:5071/api/discount");

            if (discounts != null)
            {
                Discounts = discounts.OrderBy(d => d.DiscountId).ToList();
            }
        }
    }
}
