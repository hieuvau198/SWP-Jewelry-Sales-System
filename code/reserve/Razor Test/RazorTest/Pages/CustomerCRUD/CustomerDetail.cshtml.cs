using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Pages.CustomerCRUD
{
    public class CustomerListModel : PageModel
    {
        private readonly ApiService _apiService;

        public CustomerListModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public List<Customer> Customers { get; set; }

        public async Task OnGetAsync()
        {
            var customers = await _apiService.GetAsync<List<Customer>>("http://localhost:5071/api/customer");

            if (customers != null)
            {
                Customers = customers.OrderBy(c => c.CustomerId).ToList();
            }
        }
    }
}
