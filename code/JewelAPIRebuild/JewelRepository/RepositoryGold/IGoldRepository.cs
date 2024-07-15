using JewelBO;

namespace JewelRepository.RepositoryGold
{
    public interface IGoldRepository
    {
        Task<List<Gold>> GetGolds();
        Gold GetGold(string goldId);
        Gold AddGold(Gold gold);
        Boolean RemoveGold(string goldId);
        Boolean UpdateGold(Gold gold);
    }
}
