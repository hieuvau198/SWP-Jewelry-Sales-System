using JewelSystemBE.Model;

namespace JewelSystemBE.Service.ServiceWarranty
{
    public interface IWarrantyService
    {
        List<Warranty> GetWarranties();
        Warranty GetWarranty(string warrantyId);
        bool AddWarranty(Warranty warranty);
        bool RemoveWarranty(string warrantyId);
        bool UpdateWarranty(Warranty warranty);
    }
}
