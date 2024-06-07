
using JewelBO;

namespace JewelRepository.RepositoryDiscount
{
    public interface IDiscountRepository
    {
        List<Discount> GetDiscounts();
        Discount GetDiscount(string discountId);
        bool AddDiscount(Discount discount);
        bool RemoveDiscount(string discountId);
        bool UpdateDiscount(Discount discount);
    }
}
