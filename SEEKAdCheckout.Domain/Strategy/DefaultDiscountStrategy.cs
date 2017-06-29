using System;
using System.Collections.Generic;
using System.Text;
using SEEKAdCheckout.Domain.Entities;
using System.Linq;

namespace SEEKAdCheckout.Domain.Strategy
{
    public class DefaultDiscountStrategy : DiscountStrategy
    {
        public override decimal Total(List<AdItem> items)
        {
            return items.Select(x => x.Amount).Sum();
        }
    }
}
