using JewelBO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using System.Net.Http;



namespace RazorTest.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApiService _apiService;
        public IndexModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public List<Discount> Discounts { get; set; }

        public List<Customer> Customers { get; set; }

        public List<Gem> Gems { get; set; }

        public List<Gold> Golds { get; set; }

        public List<Invoice> Invoices { get; set; }

        public List<InvoiceItem> InvoiceItems { get; set; }

        public List<Jewel> Jewels { get; set; }

        public List<Product> Products { get; set; }

        public List<User> Users { get; set; }

        public List<Warranty> Warranties { get; set; }

        public List<Login> Logins { get; set; }


        public async Task OngetAsync()
        {
            Discounts = await _apiService.GetAsync<List<Discount>>("http://localhost:5156/api/discount\r\n");

            Customers = await _apiService.GetAsync<List<Customer>>("http://localhost:5156/api/customer\r\n");

            Gems = await _apiService.GetAsync<List<Gem>>("http://localhost:5156/api/gem\r\n");

            Golds = await _apiService.GetAsync<List<Gold>>("http://localhost:5156/api/gold\r\n");

            Invoices = await _apiService.GetAsync<List<Invoice>>("http://localhost:5156/api/invoice\r\n");

            InvoiceItems = await _apiService.GetAsync<List<InvoiceItem>>("http://localhost:5156/api/invoiceitem\r\n");

            Jewels = await _apiService.GetAsync<List<Jewel>>("http://localhost:5156/api/jewel\r\n");

            Products = await _apiService.GetAsync<List<Product>>("http://localhost:5156/api/product\r\n");

            Users = await _apiService.GetAsync<List<User>>("http://localhost:5156/api/user\r\n");

            Warranties = await _apiService.GetAsync<List<Warranty>>("http://localhost:5156/api/warranty\r\n");

            //Logins = await _apiService.GetAsync<List<Login>>("http://localhost:5156/api/auth/login\r\n");

            if (Discounts != null)
            {
                Discounts = Discounts.OrderBy(d => d.DiscountId).ToList();
            }

            if (Customers != null)
            {
                Customers = Customers.OrderBy(c => c.CustomerId).ToList();
            }

            if (Gems != null)
            {
                Gems = Gems.OrderBy(g => g.GemId).ToList();
            }

            if (Golds != null)
            {
                Golds = Golds.OrderBy(b => b.GoldId).ToList();
            }

            if (Invoices != null)
            {
                Invoices = Invoices.OrderBy(i => i.InvoiceId).ToList();
            }

            if (InvoiceItems != null)
            {
                InvoiceItems = InvoiceItems.OrderBy(t => t.InvoiceItemId).ToList();
            }

            if (Jewels != null)
            {
                Jewels = Jewels.OrderBy(a => a.Id).ToList();
            }

            if (Products != null)
            {
                Products = Products.OrderBy(p => p.ProductCode).ToList();
            }

            if (Users != null)
            {
                Users = Users.OrderBy(u => u.UserId).ToList();
            }

            if (Warranties != null)
            {
                Warranties = Warranties.OrderBy(w => w.WarrantyId).ToList();
            }
        }
    }
}

