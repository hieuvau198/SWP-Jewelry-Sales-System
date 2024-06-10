using JewelBO;

namespace JewelRepository.RepositoryGold
{
    public interface IGoldRepository
    {
        List<Gold> GetGolds();
        Gold GetGold(string goldId);
        bool AddGold(Gold gold);
        bool RemoveGold(string goldId);
        bool UpdateGold(Gold gold);
    }
}
