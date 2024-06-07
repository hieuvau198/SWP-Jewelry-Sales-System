using JewelBO;
using JewelDAL;
using JewelRepository.RepositoryJewel;

namespace JewelService.ServiceJewel
{
    public class JewelService : IJewelService
    {
        private readonly IJewelRepository _jewelRepository;

        public JewelService(IJewelRepository jewelRepository)
        {
            this._jewelRepository = jewelRepository;
        }

        public bool AddJewel(Jewel jewel)
        {
            return _jewelRepository.AddJewel(jewel);
        }

        public List<Jewel> GetJewels()
        {
            return _jewelRepository.GetJewels();
        }

        public bool RemoveJewel(int jewelId)
        {
            return _jewelRepository.RemoveJewel(jewelId);
        }

        public bool UpdateJewel(Jewel jewel)
        {
            return _jewelRepository.UpdateJewel(jewel);
        }
    }
}
