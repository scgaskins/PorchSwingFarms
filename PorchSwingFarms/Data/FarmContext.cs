using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PorchSwingFarms.Models;

namespace PorchSwingFarms.Data
{
    public class FarmContext : DbContext
    {
        public FarmContext (DbContextOptions<FarmContext> options)
            : base(options)
        {
        }

        public DbSet<PorchSwingFarms.Models.Customer> Customers { get; set; }
        public DbSet<PorchSwingFarms.Models.Order> Orders { get; set; }
        public DbSet<PorchSwingFarms.Models.Subscription> Subscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<Subscription>().ToTable("Subscription");
        }
    }
}
