using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;

namespace RazorTest.Pages.pproduct
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
            var products = await _apiService.GetAsync<List<Product>>("https://hvjewel.azurewebsites.net/api/product");
        }
    }
}
