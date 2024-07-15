using JewelBO;

namespace JewelService.ServiceGold
{
    public interface IGoldService
    {
        Task<List<Gold>> GetGolds();
        Gold GetGold(string goldId);
        Gold AddGold(Gold gold);
        Boolean RemoveGold(string goldId);
        Boolean UpdateGold(Gold gold);
    }
}
