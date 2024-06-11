using JewelBO;
using JewelDAL;
using JewelRepository.RepositoryDiscount;

namespace JewelService.ServiceDiscount
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository _discountRepository;

        public DiscountService(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        public bool AddDiscount(Discount discount)
        {
            return _discountRepository.AddDiscount(discount);
        }

        public List<Discount> GetDiscounts()
        {
            return _discountRepository.GetDiscounts();
        }

        public Discount GetDiscount(string discountId)
        {
            return _discountRepository.GetDiscount(discountId);
        }

        public bool RemoveDiscount(string discountId)
        {
           return (_discountRepository.RemoveDiscount(discountId));
        }

        public bool UpdateDiscount(Discount discount)
        {
            return _discountRepository.UpdateDiscount(discount);
        }
    }
}
