using JewelBO;

namespace JewelService.ServiceStallItem
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
