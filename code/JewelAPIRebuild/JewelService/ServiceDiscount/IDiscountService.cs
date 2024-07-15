using JewelBO;

namespace JewelService.ServiceDiscount
{
    public interface IDiscountService
    {
        List<Discount> GetDiscounts();
        Discount GetDiscount(string discountId);
        Discount AddDiscount(Discount discount);
        bool RemoveDiscount(string discountId);
        bool UpdateDiscount(Discount discount);
    }
}
