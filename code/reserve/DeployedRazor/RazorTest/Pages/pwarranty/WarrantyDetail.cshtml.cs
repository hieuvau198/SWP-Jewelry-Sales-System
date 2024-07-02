using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Pages.pwarranty
{
    public class WarrantyListModel : PageModel
    {
        private readonly ApiService _apiService;

        public WarrantyListModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public List<Warranty> Warranties { get; set; }

        public async Task OnGetAsync()
        {
            var warranties = await _apiService.GetAsync<List<Warranty>>("https://jewelsystembe20240701213216.azurewebsites.net/api/warranty");

            if (warranties != null)
            {
                Warranties = warranties.OrderBy(w => w.WarrantyId).ToList();
            }
        }
    }
}
