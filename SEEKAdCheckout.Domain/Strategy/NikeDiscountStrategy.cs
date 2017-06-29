using System;
using System.Collections.Generic;
using System.Text;
using SEEKAdCheckout.Domain.Entities;
using System.Linq;

namespace SEEKAdCheckout.Domain.Strategy
{
    public class NikeDiscountStrategy : DiscountStrategy
    {
        public override decimal Total(List<AdItem> items)
        {
            var totalNonPremiumAds = items.Where(x => x.Name.ToLower() != "premium ad").Select(x => x.Amount).Sum();

            var totalPremiumAds = GetTotalOnThresholdPriceDiscount(4, items, "premium ad", 379.99m);

            return totalNonPremiumAds + totalPremiumAds;
        }
    }
}
