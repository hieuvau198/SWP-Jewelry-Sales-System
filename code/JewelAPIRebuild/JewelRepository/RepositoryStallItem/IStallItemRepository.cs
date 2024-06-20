using JewelBO;

namespace JewelRepository.RepositoryStallItem
{
    public interface IStallItemRepository
    {
        StallItem AddStallItem(StallItem stallItem);
        List<StallItem> GetStallItems();
        bool RemoveStallItem(string stallItemId);
        bool UpdateStallItem(StallItem stallItem);
        StallItem GetStallItem(string stallItemId);
    }
}
