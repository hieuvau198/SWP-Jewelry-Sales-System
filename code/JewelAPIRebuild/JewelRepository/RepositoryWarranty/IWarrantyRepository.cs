﻿

using JewelBO;

namespace JewelRepository.RepositoryWarranty
{
    public interface IWarrantyRepository
    {
        List<Warranty> GetWarranties();
        Warranty GetWarranty(string warrantyId);
        Warranty AddWarranty(Warranty warranty);
        bool RemoveWarranty(string warrantyId);
        bool UpdateWarranty(Warranty warranty);
    }
}
