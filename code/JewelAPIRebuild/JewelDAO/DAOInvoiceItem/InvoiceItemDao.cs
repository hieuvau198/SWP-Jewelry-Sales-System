using JewelBO;

namespace JewelDAO.DAOInvoiceItem
{
    public class InvoiceItemDao : IInvoiceItemDao
    {
        private readonly JewelDbContext _jewelDbContext;

        public InvoiceItemDao(JewelDbContext jewelDbContext)
        {
            this._jewelDbContext = jewelDbContext;
        }

        public InvoiceItem AddInvoiceItem(InvoiceItem invoiceItem)
        {
            if (invoiceItem == null)
            {
                return null;
            }
            var existingInvoiceItem = _jewelDbContext.InvoiceItems.Find(invoiceItem.InvoiceItemId);
            if (existingInvoiceItem != null)
            {
                return null;
            }
            try
            {
                _jewelDbContext.InvoiceItems.Add(invoiceItem);
                _jewelDbContext.SaveChanges();
                return invoiceItem;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                Console.WriteLine($"Error adding invoice item: {ex.Message}");
                return null;
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
                if (invoiceItem.ProductId != null)
                {
                    updatedInvoiceItem.ProductId = invoiceItem.ProductId;
                }
                if (invoiceItem.ProductName != null)
                {
                    updatedInvoiceItem.ProductName = invoiceItem.ProductName;
                }
                if (invoiceItem.Quantity != null)
                {
                    updatedInvoiceItem.Quantity = invoiceItem.Quantity;
                }
                if (invoiceItem.UnitPrice != null)
                {
                    updatedInvoiceItem.UnitPrice = invoiceItem.UnitPrice;
                }
                if (invoiceItem.DiscountId != null)
                {
                    updatedInvoiceItem.DiscountId = invoiceItem.DiscountId;
                }
                if (invoiceItem.DiscountRate != null)
                {
                    updatedInvoiceItem.DiscountRate = invoiceItem.DiscountRate;
                }
                if (invoiceItem.TotalPrice != null)
                {
                    updatedInvoiceItem.TotalPrice = invoiceItem.TotalPrice;
                }
                if (invoiceItem.EndTotalPrice != null)
                {
                    updatedInvoiceItem.EndTotalPrice = invoiceItem.EndTotalPrice;
                }
                if (invoiceItem.WarrantyId != null)
                {
                    updatedInvoiceItem.WarrantyId = invoiceItem.WarrantyId;
                }

                _jewelDbContext.InvoiceItems.Update(updatedInvoiceItem);
                _jewelDbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
