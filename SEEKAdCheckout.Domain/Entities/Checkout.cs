using SEEKAdCheckout.Domain.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SEEKAdCheckout.Domain.Entities
{
    public class Checkout
    {
        private IDiscountStrategy _discountStrategy;

        public Checkout(IDiscountStrategy discountStrategy)
        {
            _discountStrategy = discountStrategy;
            AdItems = new List<AdItem>();
        }

        public Guid Id { get; set; }

        public DateTime TransactionDateTime { get; set; }

        public Customer Customer { get; set; }

        private List<AdItem> AdItems { get; set; }

        public void Add(AdItem item)
        {
            AdItems.Add(item);
        }

        public decimal Total()
        {
            return _discountStrategy.Total(AdItems);
        }
    }
}
