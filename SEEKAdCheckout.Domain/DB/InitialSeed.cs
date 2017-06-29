using System;
using SEEKAdCheckout.Domain.Entities;

namespace SEEKAdCheckout.Domain.DB
{
    public static class InitialSeed
    {
        public static void Up(SEEKAdContext db)
        {
            db.Customers.AddRange(new Customer[]
                {
                    new Customer() { Id = Guid.NewGuid(), Name = "A Random Company" },
                    new Customer() { Id = Guid.NewGuid(), Name = "Apple" },
                    new Customer() { Id = Guid.NewGuid(), Name = "Ford" },
                    new Customer() { Id = Guid.NewGuid(), Name = "Nike" },
                    new Customer() { Id = Guid.NewGuid(), Name = "Unilever" }
                }
            );

            db.AdItems.AddRange(new AdItem[]
                {
                    new AdItem() { Id = "classic", Name = "Classic Ad", Amount = 269.99m },
                    new AdItem() { Id = "standout", Name = "Standout Ad", Amount = 269.99m },
                    new AdItem() { Id = "premium", Name = "Premium Ad", Amount = 269.99m }
                }
            );

            db.SaveChanges();
        }
    }
}
