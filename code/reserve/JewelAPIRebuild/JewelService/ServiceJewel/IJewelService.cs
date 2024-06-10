using JewelBO;

namespace JewelService.ServiceJewel
{
    public interface IJewelService
    {
        List<Jewel> GetJewels();

        Boolean AddJewel(Jewel jewel);
        Boolean RemoveJewel(int jewelId);
        Boolean UpdateJewel(Jewel jewel);
    }
}
