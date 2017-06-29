using SEEKAdCheckout.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEEKAdCheckout.Domain.Strategy
{
    public abstract class DiscountStrategy : IDiscountStrategy
    {
        public abstract decimal Total(List<AdItem> items);

        protected decimal GetTotalOnBulkThresholdFreeAdDiscount(int threshold, List<AdItem> items, string adName)
        {
            var counter = 0;
            var total = 0m;
            var adItems = items.Where(x => x.Name.ToLower() == adName.ToLower()).ToList();
            foreach (var item in adItems)
            {
                counter++;
                if (counter == threshold)
                {
                    counter = 0;
                }
                else
                {
                    total += item.Amount;
                }
            }

            return total;
        }

        protected decimal GetTotalOnThresholdPriceDiscount(int threshold, List<AdItem> items, string adName, decimal price)
        {
            var totalCount = items.Where(x => x.Name.ToLower() == adName.ToLower()).Count();
            if (totalCount >= threshold)
            {
                return items.Where(x => x.Name.ToLower() == adName.ToLower()).Count() * price;
            }
            return items.Where(x => x.Name.ToLower() == adName.ToLower()).Select(x => x.Amount).Sum();
        }
    }
}
