using JewelBO;
using JewelDAO.DAOGem;

namespace JewelRepository.RepositoryGem
{
    public class GemRepository : IGemRepository
    {
        private readonly IGemDao _gemDao;

        public GemRepository(IGemDao gemDao)
        {
            _gemDao = gemDao;
        }

        public bool AddGem(Gem gem)
        {
            return _gemDao.AddGem(gem);
        }

        public List<Gem> GetGems()
        {
            return _gemDao.GetGems();
        }

        public Gem GetGem(string gemId)
        {
            return _gemDao.GetGem(gemId);
        }

        public bool RemoveGem(string gemId)
        {
            return _gemDao.RemoveGem(gemId);
        }

        public bool UpdateGem(Gem gem)
        {
            return _gemDao.UpdateGem(gem);
        }
    }
}
