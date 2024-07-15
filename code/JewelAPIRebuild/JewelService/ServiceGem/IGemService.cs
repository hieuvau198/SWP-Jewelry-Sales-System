using JewelBO;

namespace JewelService.ServiceGem
{
    public interface IGemService
    {
        List<Gem> GetGems();
        Gem GetGem(string gemId);
        Gem AddGem(Gem gem);
        Boolean RemoveGem(string gemId);
        Boolean UpdateGem(Gem gem);

    }
}
