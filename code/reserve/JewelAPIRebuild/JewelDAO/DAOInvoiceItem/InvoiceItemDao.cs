using JewelBO;
using JewelDAL;

namespace JewelDAO.DAOInvoiceItem
{
    public class InvoiceItemDao : IInvoiceItemDao
    {
        private readonly JewelDbContext _jewelDbContext;

        public InvoiceItemDao(JewelDbContext jewelDbContext)
        {
            this._jewelDbContext = jewelDbContext;
        }

        public bool AddInvoiceItem(InvoiceItem invoiceItem)
        {
            if (invoiceItem == null)
            {
                return false;
            }
            var existingInvoiceItem = _jewelDbContext.InvoiceItems.Find(invoiceItem.InvoiceItemId);
            if (existingInvoiceItem != null)
            {
                return false;
            }
            try
            {
                _jewelDbContext.InvoiceItems.Add(invoiceItem);
                _jewelDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                Console.WriteLine($"Error adding invoice item: {ex.Message}");
                return false;
            }
        }

        public List<InvoiceItem> GetInvoiceItems()
        {
            return _jewelDbContext.InvoiceItems.OrderByDescending(x => x.InvoiceItemId).ToList();
        }

        public InvoiceItem GetInvoiceItem(string invoiceItemId)
        {
            return _jewelDbContext.InvoiceItems.Find(invoiceItemId);
        }

        public bool RemoveInvoiceItem(string invoiceItemId)
        {
            if (invoiceItemId == null)
            {
                return false;
            }
            var invoiceItem = _jewelDbContext.InvoiceItems.Find(invoiceItemId);
            if (invoiceItem != null)
            {
                _jewelDbContext.InvoiceItems.Remove(invoiceItem);
                _jewelDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateInvoiceItem(InvoiceItem invoiceItem)
        {
            if (invoiceItem == null)
            {
                return false;
            }
            var updatedInvoiceItem = _jewelDbContext.InvoiceItems.Find(invoiceItem.InvoiceItemId);
            if (updatedInvoiceItem != null)
            {
                updatedInvoiceItem.ProductName = invoiceItem.ProductName;
                updatedInvoiceItem.Quantity = invoiceItem.Quantity;
                updatedInvoiceItem.UnitPrice = invoiceItem.UnitPrice;
                updatedInvoiceItem.DiscountId = invoiceItem.DiscountId;
                updatedInvoiceItem.DiscountRate = invoiceItem.DiscountRate;
                updatedInvoiceItem.TotalPrice = invoiceItem.TotalPrice;
                updatedInvoiceItem.EndTotalPrice = invoiceItem.EndTotalPrice;
                updatedInvoiceItem.WarrantyId = invoiceItem.WarrantyId;
                _jewelDbContext.InvoiceItems.Update(updatedInvoiceItem);
                _jewelDbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
