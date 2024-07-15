using JewelBO;

namespace JewelRepository.RepositoryGem
{
    public interface IGemRepository
    {
        List<Gem> GetGems();
        Gem GetGem(string gemId);
        Gem AddGem(Gem gem);
        Boolean RemoveGem(string gemId);
        Boolean UpdateGem(Gem gem);
    }
}
