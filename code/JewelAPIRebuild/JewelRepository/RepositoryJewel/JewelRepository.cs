

using JewelBO;
using JewelDAO.DAOJewel;

namespace JewelRepository.RepositoryJewel
{
    public class JewelRepository : IJewelRepository
    {
        private readonly IJewelDao _jewelDao;
        public JewelRepository(IJewelDao jewelDao)
        {
            _jewelDao = jewelDao;
        }
        
        public bool AddJewel(Jewel jewel)
        {
            return _jewelDao.AddJewel(jewel);
        }

        public List<Jewel> GetJewels()
        {
            return _jewelDao.GetJewels();
        }

        public bool RemoveJewel(int jewelId)
        {
            return _jewelDao.RemoveJewel(jewelId);
        }

        public bool UpdateJewel(Jewel jewel)
        {
            return _jewelDao.UpdateJewel(jewel);
        }
    }
}
