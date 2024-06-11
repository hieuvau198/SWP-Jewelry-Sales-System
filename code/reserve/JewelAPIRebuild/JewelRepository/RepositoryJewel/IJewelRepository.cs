

using JewelBO;

namespace JewelRepository.RepositoryJewel
{
    public interface IJewelRepository
    {
        List<Jewel> GetJewels();

        Boolean AddJewel(Jewel jewel);
        Boolean RemoveJewel(int jewelId);
        Boolean UpdateJewel(Jewel jewel);
    }
}
