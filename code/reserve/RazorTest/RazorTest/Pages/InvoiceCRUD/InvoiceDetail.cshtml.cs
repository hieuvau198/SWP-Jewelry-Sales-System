using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Pages.InvoiceCRUD
{
    public class InvoiceListModel : PageModel
    {
        public const string SessionKeyAuthState = "_AuthState";
        public const string SessionKeyUserObject = "_UserObject";
        public const string SessionKeyCustomerObject = "_CustomerObject";

        private readonly ApiService _apiService;

        public InvoiceListModel(ApiService apiService)
        {
            _apiService = apiService;
        }

      //  public List<Invoice> Invoices { get; set; }
        public User User { get; set; }

        public PaginatedList<Invoice> Invoices { get; set; }

        private const int PageSize = 10;

        public async Task OnGetAsync(int currentPage = 1)
        {
            var invoices = await _apiService.GetAsync<List<Invoice>>("http://localhost:5071/api/invoice");

            if (invoices != null)
            {
                Invoices = PaginatedList<Invoice>.Create(invoices.AsQueryable(), currentPage, 10);

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
