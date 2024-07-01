using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;

namespace RazorTest.Pages.Template
{
    public class testModel : PageModel
    {
        public const string UrlTest = "https://jewelsystembe20240701213216.azurewebsites.net/api/discount\r\n";
        public const string UrlTest1 = "https://jewelsystembe20240701213216.azurewebsites.net/api/discount\r\n";
        public const string UrlStallEmployee = "https://jewelsystembe20240701213216.azurewebsites.net/api/stallemployee\r\n";
        public const string UrlStall = "https://jewelsystembe20240701213216.azurewebsites.net/api/stall\r\n";
        private readonly ApiService _apiService;
        public testModel(ApiService apiService)
        {
            _apiService = apiService;
        }
        public List<Discount> Discounts { get; set; }
        public List<StallEmployee> StallEmployees { get; set; }
        public List<Stall> Stalls { get; set; }

        public async Task OnGet()
        {
            Discounts = await _apiService.GetAsync<List<Discount>>(UrlTest);
            
        }
    }
}
