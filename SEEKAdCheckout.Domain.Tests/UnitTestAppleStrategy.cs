using SEEKAdCheckout.Domain.Entities;
using SEEKAdCheckout.Domain.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SEEKAdCheckout.Domain.Tests
{
    public class UnitTestAppleStrategy
    {
        [Fact(DisplayName = "Test_Standard_AppleStrategy")]
        public void Test_Standard_AppleStrategy()
        {
            var standoutAdItem = new AdItem() { Id = "standout", Name = "Standout Ad", Amount = 322.99m };
            var premiumAdItem = new AdItem() { Id = "premium", Name = "Premium Ad", Amount = 394.99m };

            var customer = new Customer() { Id = Guid.NewGuid(), Name = "Apple" };
            var pricingRules = DiscountStrategyFactory.GetDiscountStrategy(customer);

            var checkout = new Checkout(pricingRules)
            {
                Id = Guid.NewGuid(),
                TransactionDateTime = DateTime.Now,
                Customer = customer
            };
            checkout.Add(standoutAdItem);
            checkout.Add(standoutAdItem);
            checkout.Add(premiumAdItem);

            var total = checkout.Total();

            var expectedTotal = (premiumAdItem.Amount) + (299.99m * 2);
            Assert.Equal(expectedTotal, total);
        }

        [Fact(DisplayName = "Test_Example_Scenario_AppleStrategy")]
        public void Test_Example_Scenario_AppleStrategy()
        {
            var standoutAdItem = new AdItem() { Id = "standout", Name = "Standout Ad", Amount = 322.99m };
            var premiumAdItem = new AdItem() { Id = "premium", Name = "Premium Ad", Amount = 394.99m };

            var customer = new Customer() { Id = Guid.NewGuid(), Name = "Apple" };
            var pricingRules = DiscountStrategyFactory.GetDiscountStrategy(customer);

            var checkout = new Checkout(pricingRules)
            {
                Id = Guid.NewGuid(),
                TransactionDateTime = DateTime.Now,
                Customer = customer
            };
            checkout.Add(standoutAdItem);
            checkout.Add(standoutAdItem);
            checkout.Add(standoutAdItem);
            checkout.Add(premiumAdItem);

            var total = checkout.Total();

            Assert.Equal(1294.96m, total);
        }
    }
}
