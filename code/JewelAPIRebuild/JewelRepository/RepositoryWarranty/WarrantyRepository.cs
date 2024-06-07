

using JewelBO;
using JewelDAO.DAOWarranty;

namespace JewelRepository.RepositoryWarranty
{
    public class WarrantyRepository : IWarrantyRepository
    {
        private IWarrantyDao _warrantyDao;
        public WarrantyRepository(IWarrantyDao warrantyDao)
        {
            this._warrantyDao = warrantyDao;
        }
        public bool AddWarranty(Warranty warranty)
        {
            return _warrantyDao.AddWarranty(warranty);
        }

        public List<Warranty> GetWarranties()
        {
            return _warrantyDao.GetWarranties();
        }

        public Warranty GetWarranty(string warrantyId)
        {
            return _warrantyDao.GetWarranty(warrantyId);
        }

        public bool RemoveWarranty(string warrantyId)
        {
            return _warrantyDao.RemoveWarranty(warrantyId);
        }

        public bool UpdateWarranty(Warranty warranty)
        {
            return _warrantyDao.UpdateWarranty(warranty);
        }
    }
}
