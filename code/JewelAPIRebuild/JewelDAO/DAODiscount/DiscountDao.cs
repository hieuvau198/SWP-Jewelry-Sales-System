
using JewelBO;

namespace JewelDAO.DAODiscount
{
    public class DiscountDao : IDiscountDao
    {
        private readonly JewelDbContext _jewelDbContext;

        public DiscountDao(JewelDbContext jewelDbContext)
        {
            _jewelDbContext = jewelDbContext;
        }

        public Discount AddDiscount(Discount discount)
        {
            if (discount == null)
                return null;

            var existingDiscount = _jewelDbContext.Discounts.Find(discount.DiscountId);
            if (existingDiscount != null)
                return null;

            try
            {
                _jewelDbContext.Discounts.Add(discount);
                _jewelDbContext.SaveChanges();
                return discount;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding discount: {ex.Message}");
                return null;
            }
        }

        public List<Discount> GetDiscounts()
        {
            return _jewelDbContext.Discounts.OrderByDescending(x => x.DiscountId).ToList();
        }

        public Discount GetDiscount(string discountId)
        {
            return _jewelDbContext.Discounts.Find(discountId);
        }

        public bool RemoveDiscount(string discountId)
        {
            if (discountId == null)
                return false;

            Discount discount = _jewelDbContext.Discounts.Find(discountId);
            if (discount != null)
            {
                _jewelDbContext.Discounts.Remove(discount);
                _jewelDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateDiscount(Discount discount)
        {
            if (discount == null)
                return false;

            Discount updatedDiscount = _jewelDbContext.Discounts.Find(discount.DiscountId);
            if (updatedDiscount != null)
            {
                updatedDiscount.DiscountName = discount.DiscountName;
                updatedDiscount.OrderType = discount.OrderType;
                updatedDiscount.ProductType = discount.ProductType;
                updatedDiscount.PublicDate = discount.PublicDate;
                updatedDiscount.ExpireDate = discount.ExpireDate;
                updatedDiscount.ProductId = discount.ProductId;
                updatedDiscount.DiscountRate = discount.DiscountRate;

                _jewelDbContext.Discounts.Update(updatedDiscount);
                _jewelDbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
