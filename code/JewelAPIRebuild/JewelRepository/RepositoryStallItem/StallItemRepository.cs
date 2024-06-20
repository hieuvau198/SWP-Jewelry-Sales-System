using JewelBO;
using JewelDAO.DAOStallItem;


namespace JewelRepository.RepositoryStallItem
{
    public class StallItemRepository : IStallItemRepository
    {
        private readonly IStallItemDao _stallitemDao;
        public StallItemRepository(IStallItemDao stallItemDao) 
        { 
            _stallitemDao = stallItemDao;
        }
        public StallItem AddStallItem(StallItem stallItem)
        {
            return _stallitemDao.AddStallItem(stallItem);
        }

        public StallItem GetStallItem(string stallItemId)
        {
            return _stallitemDao.GetStallItem(stallItemId);
        }

        public List<StallItem> GetStallItems()
        {
            return _stallitemDao.GetStallItems();
        }

        public bool RemoveStallItem(string stallItemId)
        {
            return _stallitemDao.RemoveStallItem(stallItemId);
        }

        public bool UpdateStallItem(StallItem stallItem)
        {
            return _stallitemDao.UpdateStallItem(stallItem);    
        }
    }
}
