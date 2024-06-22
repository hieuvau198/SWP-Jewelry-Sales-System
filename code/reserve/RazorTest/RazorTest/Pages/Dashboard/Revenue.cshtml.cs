using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using static RazorTest.Pages.InvoiceCRUD.InvoiceListModel;

namespace RazorTest.Pages.Dashboard
{
    public class RevenueModel : PageModel
    {
        public const string UrlInvoice = "http://localhost:5071/api/invoice";

        private readonly InvoiceService _invoiceService;

        public RevenueModel(InvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        public List<Invoice> Invoices { get; set; }
        public string InvoicesJson { get; set; }
        public string BuyInvoicesJson { get; set; }


        public async Task OnGetAsync()
        {
            Invoices = await _invoiceService.GetInvoicesAsync();

            List<Invoice> saleInvoices = new List<Invoice>();
            foreach (Invoice invoice in Invoices)
            {
                if (invoice.InvoiceType.Equals("Sale"))
                {
                    saleInvoices.Add(invoice);
                }
            }
            InvoicesJson = JsonSerializer.Serialize(saleInvoices);

            List<Invoice> buyInvoices = new List<Invoice>();
            foreach (Invoice invoice in Invoices)
            {
                if (invoice.InvoiceType.Equals("Buy"))
                {
                    buyInvoices.Add(invoice);
                }
            }
            BuyInvoicesJson = JsonSerializer.Serialize(buyInvoices);
        }
    }
}

