using JewelBO;

namespace JewelDAO.DAOStallItem
{
    public interface IStallItemDao
    {
        StallItem AddStallItem(StallItem stallItem);
        List<StallItem> GetStallItems();
        bool RemoveStallItem(string stallItemId);
        bool UpdateStallItem(StallItem stallItem);
        StallItem GetStallItem(string stallItemId);
    }
}
