using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GeneralStoreAPIProject.Models
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext() : base("DefaultConncection") { } // Connected to our connection string
        public DbSet <Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}