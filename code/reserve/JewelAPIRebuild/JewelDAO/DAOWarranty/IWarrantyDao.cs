using JewelBO;

namespace JewelDAO.DAOWarranty
{
    public interface IWarrantyDao
    {
        List<Warranty> GetWarranties();
        Warranty GetWarranty(string warrantyId);
        bool AddWarranty(Warranty warranty);
        bool RemoveWarranty(string warrantyId);
        bool UpdateWarranty(Warranty warranty);
    }
}
