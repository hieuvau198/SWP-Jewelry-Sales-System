using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Pages.pcustomer
{
    public class IndexModel : PageModel
    {
        private readonly ApiService _apiService;

        public IndexModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public List<Customer> Customers { get; set; }

        public async Task OnGetAsync()
        {
            var customers = await _apiService.GetAsync<List<Customer>>("https://jewelsystembe20240701213216.azurewebsites.net/api/customer");

            if (customers != null)
            {
                Customers = customers.OrderBy(c => c.CustomerId).ToList();
            }
        }
    }
}
