
using JewelBO;
using JewelDAO.DAODiscount;

namespace JewelRepository.RepositoryDiscount
{
    public class DiscountRepository : IDiscountRepository
    {
        private IDiscountDao _discountDao;
        public DiscountRepository(IDiscountDao discountDao)
        {
            _discountDao = discountDao;
        }
        public Discount AddDiscount(Discount discount)
        {
            return _discountDao.AddDiscount(discount);
        }

        public Discount GetDiscount(string discountId)
        {
            return (_discountDao.GetDiscount(discountId));
        }

        public List<Discount> GetDiscounts()
        {
            return _discountDao.GetDiscounts();
        }

        public bool RemoveDiscount(string discountId)
        {
            return _discountDao.RemoveDiscount(discountId);
        }

        public bool UpdateDiscount(Discount discount)
        {
            return _discountDao.UpdateDiscount(discount);
        }
    }
}
