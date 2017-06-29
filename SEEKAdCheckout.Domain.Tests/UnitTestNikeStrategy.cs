using SEEKAdCheckout.Domain.Entities;
using SEEKAdCheckout.Domain.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SEEKAdCheckout.Domain.Tests
{
    public class UnitTestNikeStrategy
    {
        [Fact(DisplayName = "Test_Standard_NikeStrategy")]
        public void Test_Standard_NikeStrategy()
        {
            var standoutAdItem = new AdItem() { Id = "standout", Name = "Standout Ad", Amount = 322.99m };
            var premiumAdItem = new AdItem() { Id = "premium", Name = "Premium Ad", Amount = 394.99m };

            var customer = new Customer() { Id = Guid.NewGuid(), Name = "Nike" };
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
            checkout.Add(premiumAdItem);
            checkout.Add(premiumAdItem);
            checkout.Add(premiumAdItem);

            var total = checkout.Total();

            var expectedTotal = (standoutAdItem.Amount * 2) + (379.99m * 4);
            Assert.Equal(expectedTotal, total);
        }

        [Fact(DisplayName = "Test_Example_Scenario_NikeStrategy")]
        public void Test_Example_Scenario_NikeStrategy()
        {
            var standoutAdItem = new AdItem() { Id = "standout", Name = "Standout Ad", Amount = 322.99m };
            var premiumAdItem = new AdItem() { Id = "premium", Name = "Premium Ad", Amount = 394.99m };

            var customer = new Customer() { Id = Guid.NewGuid(), Name = "Nike" };
            var pricingRules = DiscountStrategyFactory.GetDiscountStrategy(customer);

            var checkout = new Checkout(pricingRules)
            {
                Id = Guid.NewGuid(),
                TransactionDateTime = DateTime.Now,
                Customer = customer
            };
            checkout.Add(premiumAdItem);
            checkout.Add(premiumAdItem);
            checkout.Add(premiumAdItem);
            checkout.Add(premiumAdItem);

            var total = checkout.Total();

            Assert.Equal(1519.96m, total);
        }
    }
}
