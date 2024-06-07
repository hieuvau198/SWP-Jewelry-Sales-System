using JewelBO;
using JewelDAL;

namespace JewelService.ServiceWarranty
{
    public class WarrantyService : IWarrantyService
    {
        private readonly JewelDbContext _jewelDbContext;

        public WarrantyService(JewelDbContext jewelDbContext)
        {
            this._jewelDbContext = jewelDbContext;
        }

        public bool AddWarranty(Warranty warranty)
        {
            if (warranty == null)
            {
                return false;
            }
            var existingWarranty = _jewelDbContext.Warranties.Find(warranty.WarrantyId);
            if (existingWarranty != null)
            {
                return false;
            }
            try
            {
                _jewelDbContext.Warranties.Add(warranty);
                _jewelDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                Console.WriteLine($"Error adding warranty: {ex.Message}");
                return false;
            }
        }

        public List<Warranty> GetWarranties()
        {
            return _jewelDbContext.Warranties.OrderByDescending(x => x.WarrantyId).ToList();
        }

        public Warranty GetWarranty(string warrantyId)
        {
            return _jewelDbContext.Warranties.Find(warrantyId);
        }

        public bool RemoveWarranty(string warrantyId)
        {
            if (warrantyId == null)
            {
                return false;
            }
            Warranty warranty = _jewelDbContext.Warranties.Find(warrantyId);
            if (warranty != null)
            {
                _jewelDbContext.Warranties.Remove(warranty);
                _jewelDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateWarranty(Warranty warranty)
        {
            if (warranty == null)
            {
                return false;
            }
            Warranty updatedWarranty = _jewelDbContext.Warranties.Find(warranty.WarrantyId);
            if (updatedWarranty != null)
            {
                updatedWarranty.ProductId = warranty.ProductId;
                updatedWarranty.ProductName = warranty.ProductName;
                updatedWarranty.StartDate = warranty.StartDate;
                updatedWarranty.ExpireDate = warranty.ExpireDate;
                _jewelDbContext.Warranties.Update(updatedWarranty);
                _jewelDbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
