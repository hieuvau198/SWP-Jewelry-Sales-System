using JewelBO;

namespace JewelDAO.DAOJewel
{
    public interface IJewelDao
    {
        List<Jewel> GetJewels();

        Boolean AddJewel(Jewel jewel);
        Boolean RemoveJewel(int jewelId);
        Boolean UpdateJewel(Jewel jewel);
    }
}
