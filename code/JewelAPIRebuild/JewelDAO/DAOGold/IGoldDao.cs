using JewelBO;

namespace JewelDAO.DAOGold
{
    public interface IGoldDao
    {
        Task<List<Gold>> GetGolds();
        Gold GetGold(string goldId);
        Gold AddGold(Gold gold);
        Boolean RemoveGold(string goldId);
        Boolean UpdateGold(Gold gold);
    }
}
