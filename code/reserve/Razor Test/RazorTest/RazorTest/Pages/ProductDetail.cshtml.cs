using JewelBO;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Pages
{
    public class ProductListModel : PageModel
    {
        private readonly ApiService _apiService;

        public ProductListModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public List<Product> Products { get; set; }

        public async Task OnGetAsync()
        {
            var products = await _apiService.GetAsync<List<Product>>("http://localhost:5156/api/product");

            if (products != null)
            {
                Products = products.OrderBy(p => p.ProductCode).ToList();
            }
        }
    }
}
