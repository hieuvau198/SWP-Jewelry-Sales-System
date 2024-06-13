using JewelSystemBE.Data;
using JewelSystemBE.Model;

namespace JewelSystemBE.Service.ServiceInvoice
{
    public class InvoiceService : IInvoiceService
    {
        private readonly JewelDbContext _jewelDbContext;

        public InvoiceService(JewelDbContext jewelDbContext)
        {
            this._jewelDbContext = jewelDbContext;
        }

        public Invoice AddInvoice(Invoice invoice)
        {
            if (invoice == null)
            {
                return null;
            }
            var existingInvoice = _jewelDbContext.Invoices.Find(invoice.InvoiceId);
            if (existingInvoice != null)
            {
                return null;
            }
            try
            {
                _jewelDbContext.Invoices.Add(invoice);
                _jewelDbContext.SaveChanges();
                return invoice;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                Console.WriteLine($"Error adding invoice: {ex.Message}");
                return null;
            }
        }

        public List<Invoice> GetInvoices()
        {
            return _jewelDbContext.Invoices.OrderByDescending(x => x.InvoiceId).ToList();
        }

        public Invoice GetInvoice(string invoiceId)
        {
            return _jewelDbContext.Invoices.Find(invoiceId);
        }

        public bool RemoveInvoice(string invoiceId)
        {
            if (invoiceId == null)
            {
                return false;
            }
            Invoice invoice = _jewelDbContext.Invoices.Find(invoiceId);
            if (invoice != null)
            {
                _jewelDbContext.Invoices.Remove(invoice);
                _jewelDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateInvoice(Invoice invoice)
        {
            if (invoice == null)
            {
                return false;
            }
            Invoice updatedInvoice = _jewelDbContext.Invoices.Find(invoice.InvoiceId);
            if (updatedInvoice != null)
            {
                if (invoice.InvoiceType != null)
                { updatedInvoice.InvoiceType = invoice.InvoiceType; }
                if (invoice.CustomerId != null)
                { updatedInvoice.CustomerId = invoice.CustomerId; }
                if (invoice.UserId != null)
                { updatedInvoice.UserId = invoice.UserId; }
                if (invoice.InvoiceDate != null)
                { updatedInvoice.InvoiceDate = invoice.InvoiceDate; }
                if (invoice.CustomerVoucher != null)
                { updatedInvoice.CustomerVoucher = invoice.CustomerVoucher; }
                if (invoice.InvoiceStatus != null)
                { updatedInvoice.InvoiceStatus = invoice.InvoiceStatus; }
                if (invoice.TotalPrice != null)
                { updatedInvoice.TotalPrice = invoice.TotalPrice; }
                if (invoice.EndTotalPrice != null)
                { updatedInvoice.EndTotalPrice = invoice.EndTotalPrice; }
                
                
                _jewelDbContext.Invoices.Update(updatedInvoice);
                _jewelDbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
