using JewelSystemBE.Model;

namespace JewelSystemBE.Service.ServiceStallItem
{
    public interface IStallItemService
    {
        StallItem AddStallItem(StallItem stallItem);
        List<StallItem> GetStallItems();
        bool RemoveStallItem(string stallItemId);
        bool UpdateStallItem(StallItem stallItem);
        StallItem GetStallItem(string stallItemId);
    }
}
