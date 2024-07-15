using JewelBO;
using JewelDAO.DAOGold;

namespace JewelRepository.RepositoryGold
{
    public class GoldRepository : IGoldRepository
    {
        private readonly IGoldDao _goldDao;

        public GoldRepository(IGoldDao goldDao)
        {
            _goldDao = goldDao;
        }

        public Gold AddGold(Gold gold)
        {
            return _goldDao.AddGold(gold);
        }

        public bool RemoveGold(string goldId)
        {
            return _goldDao.RemoveGold(goldId);
        }

        public bool UpdateGold(Gold gold)
        {
            return _goldDao.UpdateGold(gold);
        }

        public Gold GetGold(string goldId)
        {
            return _goldDao.GetGold(goldId);
        }

        public Task<List<Gold>> GetGolds()
        {
            return _goldDao.GetGolds();
        }
    }
}
