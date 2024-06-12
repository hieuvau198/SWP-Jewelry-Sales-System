using JewelBO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Services;

namespace RazorTest.Pages.ProductCRUD
{
    public class IndexModel : PageModel
    {
        private readonly ApiService _apiService;

        public IndexModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public List<Product> Products { get; set; }

        public async Task OnGetAsync()
        {
            var products = await _apiService.GetAsync<List<Product>>("http://localhost:5156/api/product");
        }
    }
}
