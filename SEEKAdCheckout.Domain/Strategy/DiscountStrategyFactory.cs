using SEEKAdCheckout.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEEKAdCheckout.Domain.Strategy
{
    public static class DiscountStrategyFactory
    {
        public static IDiscountStrategy GetDiscountStrategy(Customer customer)
        {
            var customerName = customer.Name.ToLower();
            switch (customerName)
            {
                case "apple":
                    return new AppleDiscoutStrategy();
                case "ford":
                    return new FordDiscountStrategy();
                case "nike":
                    return new NikeDiscountStrategy();
                case "unilever":
                    return new UnileverDiscountStrategy();
                default:
                    return new DefaultDiscountStrategy();
            }
        }
    }
}
