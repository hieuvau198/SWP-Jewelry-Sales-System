using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;

namespace RazorTest.Pages.Template
{
    public class testModel : PageModel
    {
        public const string UrlTest = "https://jewelsystembe20240627012138.azurewebsites.net/api/discount\r\n";
        public const string UrlTest1 = "http://localhost:5071/api/discount\r\n";
        public const string UrlStallEmployee = "http://localhost:5071/api/stallemployee\r\n";
        public const string UrlStall = "http://localhost:5071/api/stall\r\n";
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
            Discounts = await _apiService.GetAsync<List<Discount>>(UrlTest1);
            StallEmployees = await _apiService.GetAsync<List<StallEmployee>>(UrlStallEmployee);
            Stalls = await _apiService.GetAsync<List<Stall>>(UrlStall);
        }
    }
}
