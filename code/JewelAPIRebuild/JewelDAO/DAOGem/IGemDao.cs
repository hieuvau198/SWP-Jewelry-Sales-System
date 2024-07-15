using JewelBO;


namespace JewelDAO.DAOGem
{
    public interface IGemDao
    {
        List<Gem> GetGems();
        Gem GetGem(string gemId);
        Gem AddGem(Gem gem);
        Boolean RemoveGem(string gemId);
        Boolean UpdateGem(Gem gem);
    }
}
