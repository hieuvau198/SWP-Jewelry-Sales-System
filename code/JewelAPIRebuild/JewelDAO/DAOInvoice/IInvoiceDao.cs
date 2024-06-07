

using JewelBO;

namespace JewelDAO.DAOInvoice
{
    public interface IInvoiceDao
    {
        List<Invoice> GetInvoices();
        Invoice GetInvoice(string invoiceId);
        bool AddInvoice(Invoice invoice);
        bool RemoveInvoice(string invoiceId);
        bool UpdateInvoice(Invoice invoice);
    }
}
