

using JewelBO;
using JewelDAO.DAOStallItem;

namespace JewelRepository.RepositoryStallItem
{
    public class StallItemRepository : IStallItemRepository
    {
        private readonly IStallItemDao _stallItemDao;
        public StallItemRepository(IStallItemDao stallItemDao)
        {
            _stallItemDao = stallItemDao;
        }

        public StallItem AddStallItem(StallItem stallItem)
        {
            return _stallItemDao.AddStallItem(stallItem);
        }

        public StallItem GetStallItem(string stallItemId)
        {
            return _stallItemDao.GetStallItem(stallItemId);
        }

        public List<StallItem> GetStallItems()
        {
            return _stallItemDao.GetStallItems();
        }

        public bool RemoveStallItem(string stallItemId)
        {
            return _stallItemDao.RemoveStallItem(stallItemId);
        }

        public bool UpdateStallItem(StallItem stallItem)
        {
            return _stallItemDao.UpdateStallItem(stallItem);
        }
    }
}
