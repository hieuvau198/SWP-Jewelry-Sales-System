using JewelBO;
using JewelRepository.RepositoryGold;

namespace JewelService.ServiceGold
{
    public class GoldService : IGoldService
    {
        private readonly IGoldRepository _goldRepository;

        public GoldService(IGoldRepository goldRepository)
        {
            _goldRepository = goldRepository;
        }

        public Gold AddGold(Gold gold)
        {
            return _goldRepository.AddGold(gold);
        }

        public bool RemoveGold(string goldId)
        {
            return _goldRepository.RemoveGold(goldId);
        }

        public bool UpdateGold(Gold gold)
        {
            return _goldRepository.UpdateGold(gold);
        }

        public Gold GetGold(string goldId)
        {
            return _goldRepository.GetGold(goldId);
        }

        public Task<List<Gold>> GetGolds()
        {
            return _goldRepository.GetGolds();
        }
    }
}
