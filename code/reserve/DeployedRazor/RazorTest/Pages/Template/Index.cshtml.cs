using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorTest.Pages.Template
{
    public class IndexModel : PageModel
    {
        public string CompanyName { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DueDate { get; set; }
        public string CompanyAddress { get; set; }
        public string ContactDetails { get; set; }
        public string BillToContactName { get; set; }
        public string BillToCompanyName { get; set; }
        public string BillToAddress { get; set; }
        public string PaymentMethod { get; set; }
        public string CheckNumber { get; set; }
        public List<Item> Items { get; set; }
        public decimal TotalAmount { get; set; }

        public void OnGet()
        {
            // Set default values for the sake of example
            CompanyName = "Your Company Name";
            InvoiceNumber = "123";
            CreatedDate = DateTime.Now;
            DueDate = DateTime.Now.AddDays(30);
            CompanyAddress = "Your Company Address";
            ContactDetails = "Your Contact Details";
            BillToContactName = "Contact Name";
            BillToCompanyName = "Company Name";
            BillToAddress = "Address";
            PaymentMethod = "Check";
            CheckNumber = "1000";
            Items = new List<Item>
        {
            new Item { Description = "Item 1", Price = 300.00M },
            new Item { Description = "Item 2", Price = 200.00M },
            new Item { Description = "Item 3", Price = 150.00M }
        };
            TotalAmount = 650.00M;
        }
    }
    public class Item
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
