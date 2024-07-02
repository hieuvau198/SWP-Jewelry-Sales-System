using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Pages.pcustomer
{
    public class CustomerListModel : PageModel
    {
        private readonly ApiService _apiService;

        public CustomerListModel(ApiService apiService)
        {
            _apiService = apiService;
        }

       // public List<Customer> Customers { get; set; }

        public PaginatedList<Customer> Customers { get; set; }

        public const int PageSize = 3; 

        public async Task OnGetAsync(int currentPage = 1)
        {
            var customers = await _apiService.GetAsync<List<Customer>>("https://jewelsystembe20240701213216.azurewebsites.net/api/customer");

            if (customers != null)
            {
                Customers = PaginatedList<Customer>.Create(customers.AsQueryable(), currentPage, 3);

            }
        }
    }
}
