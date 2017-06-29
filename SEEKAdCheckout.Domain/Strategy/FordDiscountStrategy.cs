using System;
using System.Collections.Generic;
using System.Text;
using SEEKAdCheckout.Domain.Entities;
using System.Linq;

namespace SEEKAdCheckout.Domain.Strategy
{
    public class FordDiscountStrategy : DiscountStrategy
    {
        public override decimal Total(List<AdItem> items)
        {
            var totalClassicAds = GetTotalOnBulkThresholdFreeAdDiscount(5, items, "classic ad");

            var totalStandoutAds = GetTotalOnThresholdPriceDiscount(1, items, "standout ad", 309.99m);

            var totalPremiumAds = GetTotalOnThresholdPriceDiscount(3, items, "premium ad", 389.99m);

            return totalClassicAds + totalStandoutAds + totalPremiumAds;
        }
    }
}
