using Microsoft.EntityFrameworkCore;
using SuperMarket.Entity.Entities;
using SuperMarket.Map.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.DAL.Context
{
    public class MyDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlServer(GetConnectionString());
        }

        private static string GetConnectionString()
        {
            const string databaseName = "SuperMarket";

            return $"Server=localhost;" +
                   $"database={databaseName};" +
                   $"Trusted_Connection = True;" +
                   $"MultipleActiveResultSets = True;" +
                    $"pooling=true;";
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AppUserMapping());
            builder.ApplyConfiguration(new OrderDetailMapping());
            builder.ApplyConfiguration(new OrderMapping());
            builder.ApplyConfiguration(new CartItemMapping());
            builder.ApplyConfiguration(new CartMapping());
            builder.ApplyConfiguration(new CategoryMapping());
            builder.ApplyConfiguration(new ProductMapping());
            base.OnModelCreating(builder);
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }



    }
}
