

using JewelBO;
using JewelDAO.DAOInvoice;

namespace JewelRepository.RepositoryInvoice
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly IInvoiceDao _invoiceDao;

        public InvoiceRepository(IInvoiceDao invoiceDao)
        { 
            _invoiceDao = invoiceDao;
        }
        
        public Invoice AddInvoice(Invoice invoice)
        {
            return _invoiceDao.AddInvoice(invoice);
        }

        public Invoice GetInvoice(string invoiceId)
        {
            return _invoiceDao.GetInvoice(invoiceId);
        }

        public List<Invoice> GetInvoices()
        {
            return _invoiceDao.GetInvoices();
        }

        public bool RemoveInvoice(string invoiceId)
        {
            return _invoiceDao.RemoveInvoice(invoiceId);
        }

        public bool UpdateInvoice(Invoice invoice)
        {
            return _invoiceDao.UpdateInvoice(invoice);
        }
    }
}
