using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Pages.pdiscount
{
    public class DiscountListModel : PageModel
    {
        private readonly ApiService _apiService;

        public DiscountListModel(ApiService apiService)
        {
            _apiService = apiService;
        }

       // public List<Discount> Discounts { get; set; }
        public PaginatedList<Discount> Discounts { get; set; }

        private const int PageSize = 10;
 
        public async Task OnGetAsync(int currentPage = 1)
        {
            var discounts = await _apiService.GetAsync<List<Discount>>("http://localhost:5071/api/discount");

            if (discounts != null)
            {
                Discounts = PaginatedList<Discount>.Create(discounts.AsQueryable(), currentPage, 10);
            }
        }
    }
}
