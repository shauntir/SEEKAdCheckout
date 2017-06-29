using SEEKAdCheckout.Domain.Entities;
using SEEKAdCheckout.Domain.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SEEKAdCheckout.Domain.Tests
{
    public class UnitTestUnileverStrategy
    {
        [Fact(DisplayName = "Test_Standard_UnileverStrategy")]
        public void Test_Standard_UnileverStrategy()
        {
            var classicAdItem = new AdItem() { Id = "classic", Name = "Classic Ad", Amount = 269.99m };
            var premiumAdItem = new AdItem() { Id = "premium", Name = "Premium Ad", Amount = 394.99m };
            var customer = new Customer() { Id = Guid.NewGuid(), Name = "Unilever" };
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
            checkout.Add(premiumAdItem);

            var total = checkout.Total();

            var expectedTotal = (premiumAdItem.Amount) + (classicAdItem.Amount * 2);
            Assert.Equal(expectedTotal, total);
        }
    }
}
