using JewelBO;
using JewelDAL;

namespace JewelDAO.DAOStallItem
{
    public class StallItemDao : IStallItemDao
    {
        private readonly JewelDbContext _jewelDbContext;

        public StallItemDao(JewelDbContext jewelDbContext)
        {
            this._jewelDbContext = jewelDbContext;
        }

        public StallItem AddStallItem(StallItem stallItem)
        {
            if (stallItem == null)
            {
                return null;
            }
            var existingStallItem = _jewelDbContext.StallItems.Find(stallItem.StallItemId);
            if (existingStallItem != null)
            {
                return null;
            }
            try
            {
                _jewelDbContext.StallItems.Add(stallItem);
                _jewelDbContext.SaveChanges();
                return stallItem;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding stall item: {ex.Message}");
                return null;
            }
        }

        public List<StallItem> GetStallItems()
        {
            return _jewelDbContext.StallItems.OrderByDescending(x => x.StallItemId).ToList();
        }

        public bool RemoveStallItem(string stallItemId)
        {
            if (stallItemId == null)
            {
                return false;
            }
            StallItem stallItem = _jewelDbContext.StallItems.Find(stallItemId);
            if (stallItem != null)
            {
                _jewelDbContext.StallItems.Remove(stallItem);
                _jewelDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateStallItem(StallItem stallItem)
        {
            if (stallItem == null)
            {
                return false;
            }
            StallItem updatedStallItem = _jewelDbContext.StallItems.Find(stallItem.StallItemId);
            if (updatedStallItem != null)
            {
                updatedStallItem.ProductId = stallItem.ProductId;
                updatedStallItem.ProductName = stallItem.ProductName;
                updatedStallItem.quantity = stallItem.quantity;
                _jewelDbContext.StallItems.Update(updatedStallItem);
                _jewelDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public StallItem GetStallItem(string stallItemId)
        {
            return _jewelDbContext.StallItems.Find(stallItemId);
        }
    }
}
