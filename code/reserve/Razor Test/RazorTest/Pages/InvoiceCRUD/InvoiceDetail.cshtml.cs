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
        public const string SessionKeyCustomerList = "_CustomerList";
        public const string SessionKeyUserList = "_UserList";

        public const string UrlGetCustomers = "http://localhost:5071/api/customer\r\n";
        public const string UrlGetUsers = "http://localhost:5071/api/user\r\n";

        private readonly ApiService _apiService;

        public InvoiceListModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public List<Invoice> Invoices { get; set; }
        public User User { get; set; }
        public List<User> Users { get; set; }
        public List<Customer> Customers { get; set; }


        public async Task OnGetAsync()
        {
            var invoices = await _apiService.GetAsync<List<Invoice>>("http://localhost:5071/api/invoice");

            if (invoices != null)
            {
                Invoices = invoices.OrderBy(c => c.InvoiceId).ToList();
            }
            Users = HttpContext.Session.GetObject<List<User>>(SessionKeyUserList) 
                ?? await _apiService.GetAsync<List<User>>(SessionKeyUserList);
                
            
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
