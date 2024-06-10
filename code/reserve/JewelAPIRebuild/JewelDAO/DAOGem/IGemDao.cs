using JewelBO;


namespace JewelDAO.DAOGem
{
    public interface IGemDao
    {
        List<Gem> GetGems();
        Gem GetGem(string gemId);
        bool AddGem(Gem gem);
        bool RemoveGem(string gemId);
        bool UpdateGem(Gem gem);
    }
}
