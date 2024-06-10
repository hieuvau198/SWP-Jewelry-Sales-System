
using JewelBO;
using JewelDAL;

namespace JewelDAO.DAOInvoice
{
    public class InvoiceDao : IInvoiceDao
    {
        private readonly JewelDbContext _jewelDbContext;

        public InvoiceDao(JewelDbContext jewelDbContext)
        {
            this._jewelDbContext = jewelDbContext;
        }

        public bool AddInvoice(Invoice invoice)
        {
            if (invoice == null)
            {
                return false;
            }
            var existingInvoice = _jewelDbContext.Invoices.Find(invoice.InvoiceId);
            if (existingInvoice != null)
            {
                return false;
            }
            try
            {
                _jewelDbContext.Invoices.Add(invoice);
                _jewelDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                Console.WriteLine($"Error adding invoice: {ex.Message}");
                return false;
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
                updatedInvoice.InvoiceType = invoice.InvoiceType;
                updatedInvoice.CustomerId = invoice.CustomerId;
                updatedInvoice.UserId = invoice.UserId;
                updatedInvoice.InvoiceDate = invoice.InvoiceDate;
                updatedInvoice.CustomerVoucher = invoice.CustomerVoucher;
                updatedInvoice.TotalPrice = invoice.TotalPrice;
                updatedInvoice.EndTotalPrice = invoice.EndTotalPrice;
                _jewelDbContext.Invoices.Update(updatedInvoice);
                _jewelDbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
