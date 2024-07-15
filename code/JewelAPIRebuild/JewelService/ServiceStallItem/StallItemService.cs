

using JewelBO;
using JewelRepository.RepositoryStallItem;

namespace JewelService.ServiceStallItem
{
    public class StallItemService : IStallItemService
    {
        private IStallItemRepository _stallItemRepository;
        public StallItemService(IStallItemRepository stallItemRepository)
        {
            _stallItemRepository = stallItemRepository;
        }

        public StallItem AddStallItem(StallItem stallItem)
        {
            return _stallItemRepository.AddStallItem(stallItem);
        }

        public StallItem GetStallItem(string stallItemId)
        {
            return _stallItemRepository.GetStallItem(stallItemId);
        }

        public List<StallItem> GetStallItems()
        {
            return _stallItemRepository.GetStallItems();
        }

        public bool RemoveStallItem(string stallItemId)
        {
            return _stallItemRepository.RemoveStallItem(stallItemId);
        }

        public bool UpdateStallItem(StallItem stallItem)
        {
            return _stallItemRepository.UpdateStallItem(stallItem);
        }
    }
}
