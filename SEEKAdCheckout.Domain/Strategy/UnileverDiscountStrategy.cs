using System;
using System.Collections.Generic;
using System.Text;
using SEEKAdCheckout.Domain.Entities;
using System.Linq;

namespace SEEKAdCheckout.Domain.Strategy
{
    public class UnileverDiscountStrategy : DiscountStrategy
    {
        public override decimal Total(List<AdItem> items)
        {
            var totalNonClassicAds = items.Where(x => x.Name.ToLower() != "classic ad").Select(x => x.Amount).Sum();

            var totalClassicAds = GetTotalOnBulkThresholdFreeAdDiscount(3, items, "classic ad");

            return totalClassicAds + totalNonClassicAds;
        }
    }
}
