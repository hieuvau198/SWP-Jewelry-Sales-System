
using JewelBO;

namespace JewelDAO.DAODiscount
{
    public interface IDiscountDao
    {
        List<Discount> GetDiscounts();
        Discount GetDiscount(string discountId);
        Discount AddDiscount(Discount discount);
        bool RemoveDiscount(string discountId);
        bool UpdateDiscount(Discount discount);
    }
}
