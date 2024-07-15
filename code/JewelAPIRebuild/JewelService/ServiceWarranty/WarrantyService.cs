using JewelBO;
using JewelRepository.RepositoryWarranty;

namespace JewelService.ServiceWarranty
{
    public class WarrantyService : IWarrantyService
    {
        private readonly IWarrantyRepository _warrantyRepository;

        public WarrantyService(IWarrantyRepository warrantyRepository)
        {
            this._warrantyRepository = warrantyRepository;
        }

        public Warranty AddWarranty(Warranty warranty)
        {
            return _warrantyRepository.AddWarranty(warranty);
        }

        public List<Warranty> GetWarranties()
        {
            return _warrantyRepository.GetWarranties();
        }

        public Warranty GetWarranty(string warrantyId)
        {
            return _warrantyRepository.GetWarranty(warrantyId);
        }

        public bool RemoveWarranty(string warrantyId)
        {
            return _warrantyRepository.RemoveWarranty(warrantyId);
        }

        public bool UpdateWarranty(Warranty warranty)
        {
            return _warrantyRepository.UpdateWarranty(warranty);
        }
    }
}
