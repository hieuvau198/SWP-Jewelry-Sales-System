using JewelBO;

namespace JewelService.ServiceWarranty
{
    public interface IWarrantyService
    {
        List<Warranty> GetWarranties();
        Warranty GetWarranty(string warrantyId);
        Warranty AddWarranty(Warranty warranty);
        bool RemoveWarranty(string warrantyId);
        bool UpdateWarranty(Warranty warranty);
    }
}
