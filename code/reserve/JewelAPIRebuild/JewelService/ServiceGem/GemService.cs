using JewelBO;
using JewelRepository.RepositoryGem;

namespace JewelService.ServiceGem
{
    public class GemService : IGemService
    {
        private readonly IGemRepository _gemRepository;
        public GemService(IGemRepository gemRepository)
        {
            _gemRepository = gemRepository;
        }
        public bool AddGem(Gem gem)
        {
            return _gemRepository.AddGem(gem);
        }
        public bool RemoveGem(string gemId)
        {
            return _gemRepository.RemoveGem(gemId);
        }
        public bool UpdateGem(Gem gem)
        {
            return _gemRepository.UpdateGem(gem);
        }
        public Gem GetGem(string gemId)
        {
            return _gemRepository.GetGem(gemId);
        }
        public List<Gem> GetGems()
        {
            return _gemRepository.GetGems();
        }
    }
}
