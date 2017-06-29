using System;
using System.Collections.Generic;
using System.Text;
using SEEKAdCheckout.Domain.Entities;
using System.Linq;

namespace SEEKAdCheckout.Domain.Strategy
{
    public class AppleDiscoutStrategy : DiscountStrategy
    {
        public override decimal Total(List<AdItem> items)
        {
            var totalNonStandoutAds = items.Where(x => x.Name.ToLower() != "standout ad").Select(x => x.Amount).Sum();

            var totalStandoutAds = GetTotalOnThresholdPriceDiscount(1, items, "standout ad", 299.99m);

            return totalNonStandoutAds + totalStandoutAds;
        }
    }
}
