using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Pages.InvoiceCRUD
{
    public class IndexModel : PageModel
    {
        public const string SessionKeyAuthState = "_AuthState";
        public const string SessionKeyUserObject = "_UserObject";
        private readonly ApiService _apiService;

        public IndexModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public List<Invoice> Invoices { get; set; }
        public User User { get; set; }

        public async Task OnGetAsync()
        {
            var invoices = await _apiService.GetAsync<List<Invoice>>("https://jewelsystembe20240701213216.azurewebsites.net/api/invoice");

            if (invoices != null)
            {
                Invoices = invoices.OrderBy(c => c.InvoiceDate).ToList();
            }
        }
        public bool VerifyAuth(string role)
        {
            bool result = false;
            if (HttpContext.Session.GetObject<bool>(SessionKeyAuthState)
                && HttpContext.Session.GetObject<User>(SessionKeyUserObject).Role.Equals(role))
            {
                result = true;
            }
            return result;
        }
    }
}
