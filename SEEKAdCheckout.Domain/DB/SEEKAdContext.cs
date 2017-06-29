using Microsoft.EntityFrameworkCore;
using SEEKAdCheckout.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEEKAdCheckout.Domain.DB
{
    public class SEEKAdContext : DbContext
    {
        public SEEKAdContext(DbContextOptions<SEEKAdContext> options)
            : base(options)
        {
        }

        public SEEKAdContext()
        {
        }

        public DbSet<AdItem> AdItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }
    }
}
