using SEEKAdCheckout.Domain.Entities;
using SEEKAdCheckout.Domain.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SEEKAdCheckout.Domain.Tests
{
    public class UnitTestFordStrategy
    {
        [Fact(DisplayName = "Test_Standard_FordStrategy")]
        public void Test_Standard_FordStrategy()
        {
            var classicAdItem = new AdItem() { Id = "classic", Name = "Classic Ad", Amount = 269.99m };
            var standoutAdItem = new AdItem() { Id = "standout", Name = "Standout Ad", Amount = 322.99m };
            var premiumAdItem = new AdItem() { Id = "premium", Name = "Premium Ad", Amount = 394.99m };

            var customer = new Customer() { Id = Guid.NewGuid(), Name = "Ford" };
            var pricingRules = DiscountStrategyFactory.GetDiscountStrategy(customer);

            var checkout = new Checkout(pricingRules)
            {
                Id = Guid.NewGuid(),
                TransactionDateTime = DateTime.Now,
                Customer = customer
            };
            checkout.Add(classicAdItem);
            checkout.Add(classicAdItem);
            checkout.Add(classicAdItem);
            checkout.Add(classicAdItem);
            checkout.Add(classicAdItem);

            checkout.Add(standoutAdItem);
            checkout.Add(standoutAdItem);

            checkout.Add(premiumAdItem);
            checkout.Add(premiumAdItem);
            checkout.Add(premiumAdItem);
            checkout.Add(premiumAdItem);

            var total = checkout.Total();

            var expectedTotal = (classicAdItem.Amount * 4) + (309.99m * 2) + (389.99m * 4);
            Assert.Equal(expectedTotal, total);
        }
    }
}
