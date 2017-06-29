using SEEKAdCheckout.Domain.Entities;
using SEEKAdCheckout.Domain.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SEEKAdCheckout.Domain.Tests
{
    public class UnitTestDefaultStrategy
    {
        [Fact(DisplayName = "Test_Standard_Default_Strategy")]
        public void Test_Standard_Default_Strategy()
        {
            var classicAdItem = new AdItem() { Id = "classic", Name = "Classic Ad", Amount = 269.99m };
            var standoutAdItem = new AdItem() { Id = "standout", Name = "Standout Ad", Amount = 322.99m };
            var premiumAdItem = new AdItem() { Id = "premium", Name = "Premium Ad", Amount = 394.99m };

            var customer = new Customer() { Id = Guid.NewGuid(), Name = "A Random Company" };
            var pricingRules = DiscountStrategyFactory.GetDiscountStrategy(customer);

            var checkout = new Checkout(pricingRules)
            {
                Id = Guid.NewGuid(),
                TransactionDateTime = DateTime.Now,
                Customer = customer
            };
            checkout.Add(classicAdItem);
            checkout.Add(premiumAdItem);

            Assert.Equal(664.98m, checkout.Total());
        }

        [Fact(DisplayName = "Test_Example_Scenario_Default_Strategy")]
        public void Test_Example_Scenario_Default_Strategy()
        {
            var classicAdItem = new AdItem() { Id = "classic", Name = "Classic Ad", Amount = 269.99m };
            var standoutAdItem = new AdItem() { Id = "standout", Name = "Standout Ad", Amount = 322.99m };
            var premiumAdItem = new AdItem() { Id = "premium", Name = "Premium Ad", Amount = 394.99m };

            var customer = new Customer() { Id = Guid.NewGuid(), Name = "A Random Company" };
            var pricingRules = DiscountStrategyFactory.GetDiscountStrategy(customer);

            var checkout = new Checkout(pricingRules)
            {
                Id = Guid.NewGuid(),
                TransactionDateTime = DateTime.Now,
                Customer = customer
            };
            checkout.Add(classicAdItem);
            checkout.Add(standoutAdItem);
            checkout.Add(premiumAdItem);

            Assert.Equal(987.97m, checkout.Total());
        }
    }
}
