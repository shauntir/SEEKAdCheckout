using System.Collections.Generic;
using SEEKAdCheckout.Domain.Entities;

namespace SEEKAdCheckout.Domain.Strategy
{
    public interface IDiscountStrategy
    {
        decimal Total(List<AdItem> items);
    }
}