using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Pages.WarrantyCRUD
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
            var warranties = await _apiService.GetAsync<List<Warranty>>("http://localhost:5071/api/warranty");

            if (warranties != null)
            {
                Warranties = warranties.OrderBy(w => w.WarrantyId).ToList();
            }
        }
    }
}
