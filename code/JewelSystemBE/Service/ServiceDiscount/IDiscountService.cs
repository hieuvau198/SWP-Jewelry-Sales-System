﻿using JewelSystemBE.Model;

namespace JewelSystemBE.Service.ServiceDiscount
{
    public interface IDiscountService
    {
        List<Discount> GetDiscounts();
        Discount GetDiscount(string discountId);
        bool AddDiscount(Discount discount);
        bool RemoveDiscount(string discountId);
        bool UpdateDiscount(Discount discount);
    }
}
