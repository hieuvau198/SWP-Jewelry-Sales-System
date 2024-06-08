using JewelSystemBE.Model;

namespace JewelSystemBE.Service.ServiceJewelP
{
    public interface IJewelPService
    {
        List<JewelP> GetAll();
        JewelP GetJewelP(string name);
        bool AddJewelP(JewelP jewelP);
    }
}
