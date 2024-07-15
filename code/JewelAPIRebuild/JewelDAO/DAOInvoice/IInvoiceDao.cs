

using JewelBO;

namespace JewelDAO.DAOInvoice
{
    public interface IInvoiceDao
    {
        List<Invoice> GetInvoices();
        Invoice GetInvoice(string invoiceId);
        Invoice AddInvoice(Invoice invoice);
        bool RemoveInvoice(string invoiceId);
        bool UpdateInvoice(Invoice invoice);
    }
}
